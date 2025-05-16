using BigoAds.Scripts.Common;

namespace BigoAds.Scripts.Api
{
    public class BigoPopupAd : BigoBaseAd<BigoPopupRequest>
    {
        public BigoPopupAd(string slotId) : base(slotId, BigoAdSdk.GetClientFactory().BuildPopupAdClient())
        {
        }
    }
}