#if UNITY_IOS
using BigoAds.Scripts.Api;
using BigoAds.Scripts.Common;

namespace BigoAds.Scripts.Platforms.iOS.Adapter.BigoAd
{

    class BigoUnitypopupAd : BigoIOSBaseAd, IPopupAd
    {
        public void Load(string slotId, BigoPopupRequest request)
        {
            adType = 6;
            LoadAdData(slotId,request);
        }
    }
}
#endif
