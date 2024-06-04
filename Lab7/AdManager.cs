// Khởi tạo quảng cáo Banner khi game bắt đầu, sau đó sẽ tự động ẩn quảng cáo sau 15 giây bằng cách sử dụng hàm Invoke.

using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    private BannerView bannerAd;

    // ID của quảng cáo Banner trong tài khoản AdMob của bạn
    private string bannerAdUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/yyyyyyyyyy";

    void Start()
    {
        // Khởi tạo SDK của Google AdMob
        MobileAds.Initialize(initStatus => { });

        // Tạo và load quảng cáo Banner
        bannerAd = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        bannerAd.LoadAd(request);

        // Hiển thị quảng cáo Banner trong 15 giây
        Invoke("HideBannerAd", 15f);
    }

    void HideBannerAd()
    {
        bannerAd.Hide();
    }

    void OnDestroy()
    {
        // Xóa quảng cáo Banner khi đối tượng bị hủy
        if (bannerAd != null)
        {
            bannerAd.Destroy();
        }
    }
}
