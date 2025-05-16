#if UNITY_ANDROID
using System;
using BigoAds.Scripts.Api;
using BigoAds.Scripts.Api.Constant;
using BigoAds.Scripts.Common;
using UnityEngine;

namespace BigoAds.Scripts.Platforms.Android
{
    class AndroidPopupAd : IPopupAd
    {
        private const string PopupAdLoaderClassName = AndroidPlatformTool.ClassPackage + ".api.popup.PopupAdLoader$Builder";
        private const string PopupAdRequestClassName = AndroidPlatformTool.ClassPackage + ".api.popup.PopupAdRequest$Builder";
        private const string PopupBuildMethod = "build";
        private const string PopupAdLoaderBuildMethod = "withAdLoadListener";
        private const string PopupAdLoaderExtMethod = "withExt";

        private AndroidJavaObject PopupAd;

        public event Action OnLoad;
        public event Action<int, string> OnLoadFailed;
        public event Action OnAdShowed;
        public event Action OnAdClicked;
        public event Action OnAdDismissed;
        public event Action<int, string> OnAdError;

        public AndroidPopupAd()
        {
            OnAdLoad += ((ad) => 
            {
                PopupAd = ad;
                OnLoad?.Invoke();
            });
        }

        private event Action<AndroidJavaObject> OnAdLoad;

        public void Load(string slotId, BigoPopupRequest request)
        {
            if (request == null)
            {
                return;
            }
            var PopupLoaderBuilder = new AndroidJavaObject(PopupAdLoaderClassName);
            PopupLoaderBuilder?.Call<AndroidJavaObject>(PopupAdLoaderExtMethod, request.ExtraInfoJson);
            PopupLoaderBuilder?.Call<AndroidJavaObject>(PopupAdLoaderBuildMethod, new AdLoadCallback(OnAdLoad, OnLoadFailed));
            var PopupLoader = PopupLoaderBuilder?.Call<AndroidJavaObject>(PopupBuildMethod);
        
            var PopupRequestBuilder = new AndroidJavaObject(PopupAdRequestClassName);
            PopupRequestBuilder?.Call<AndroidJavaObject>("withSlotId", slotId);
            PopupRequestBuilder?.Call<AndroidJavaObject>("withAge", request.Age);
            PopupRequestBuilder?.Call<AndroidJavaObject>("withGender", (int)(request.Gender));
            PopupRequestBuilder?.Call<AndroidJavaObject>("withActivatedTime", request.ActivatedTime);

            var PopupRequest = PopupRequestBuilder?.Call<AndroidJavaObject>(PopupBuildMethod);

            PopupLoader?.Call("loadAd", PopupRequest);
        }

        public bool IsLoaded()
        {
            return PopupAd != null;
        }

        public void Show()
        {
            PopupAd?.Call("setAdInteractionListener", new AdInteractionCallback(OnAdShowed, OnAdClicked, OnAdDismissed, OnAdError));
            AndroidPlatformTool.CallMethodOnMainThread(() => 
            {
                PopupAd?.Call("show");
            });
            
        }

        public void Destroy()
        {
            //post to main 
            AdHelper.DestroyAd(PopupAd);
        }

        public bool IsExpired()
        {
            return PopupAd != null && PopupAd.Call<bool>("isExpired");
        }

        public bool IsClientBidding()
        {
            if (PopupAd == null) return false;
            AndroidJavaObject bid = PopupAd.Call<AndroidJavaObject>("getBid");
            return bid != null;
        }

        public string GetExtraInfo(string key)
        {
            if (PopupAd == null) return "";
            return PopupAd.Call<string>("getExtraInfo", key);
        }

        /// get price
        public double getPrice()
        {
            if (PopupAd == null) return 0;
            AndroidJavaObject bid = PopupAd.Call<AndroidJavaObject>("getBid");
            return bid == null ? 0 : bid.Call<double>("getPrice");
        }

        ///notify win
        public void notifyWin(double secPrice, string secBidder)
        {
            if (PopupAd == null) return;
            var secPriceDouble = new AndroidJavaClass("java.lang.Double").CallStatic<AndroidJavaObject> ("valueOf", secPrice);
            PopupAd.Call<AndroidJavaObject>("getBid")?.Call("notifyWin", secPriceDouble, secBidder);
        }

        ///notify loss
        public void notifyLoss(double firstPrice, string firstBidder, BGAdLossReason lossReason)
        {
            if (PopupAd == null) return;
            var firstPriceDouble = new AndroidJavaClass("java.lang.Double").CallStatic<AndroidJavaObject> ("valueOf", firstPrice);
            PopupAd.Call<AndroidJavaObject>("getBid")?.Call("notifyLoss", firstPriceDouble, firstBidder, (int)lossReason);
        }
    }
}
#endif