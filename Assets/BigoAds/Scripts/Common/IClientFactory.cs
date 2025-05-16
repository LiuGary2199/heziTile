namespace BigoAds.Scripts.Common
{
    public interface IClientFactory
    {
        ISDK BuildSDKClient();
        IBannerAd BuildBannerAdClient();
        INativeAd BuildNativeAdClient();
        IInterstitialAd BuildInterstitialAdClient();
        IPopupAd BuildPopupAdClient();
        ISplashAd BuildSplashAdClient();
        IRewardedAd BuildRewardedAdClient();
    }
}