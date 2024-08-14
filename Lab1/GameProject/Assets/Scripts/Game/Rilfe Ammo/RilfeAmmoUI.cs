using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RifleAmmoUI : MonoBehaviour
{
    // Tham chiếu đến Text UI để hiển thị số đạn còn lại của rifle
    [SerializeField]
    private TMP_Text _rifleAmmoText;

    // Tham chiếu đến PlayerShoot để lấy thông tin số đạn còn lại
    [SerializeField]
    private PlayerShoot _playerShoot;

    // Được gọi mỗi khung hình để cập nhật UI
    void Update()
    {
        UpdateAmmoUI();
    }

    // Cập nhật giao diện UI để hiển thị số đạn còn lại
    private void UpdateAmmoUI()
    {
        if (_playerShoot.HasRifle())
        {
            // Nếu người chơi đã nhặt được súng rifle, tính toán số đạn còn lại
            int remainingAmmo = _playerShoot.GetRemainingAmmo();

            // Kiểm tra nếu số đạn còn lại là 0
            if (remainingAmmo <= 0 || remainingAmmo > 40)
            {
                // Hiển thị thông báo "Hết đạn"
                _rifleAmmoText.text = "Pistol Ammo: Infinity";
            }
            else
            {
                // Hiển thị số đạn còn lại
                _rifleAmmoText.text = $"Rifle Ammo: {remainingAmmo}";
            }
        }
        else
        {
            // Nếu người chơi chưa nhặt được súng rifle, hiển thị thông báo "N/A"
            _rifleAmmoText.text = "Pistol Ammo: Infinity";
        }
    }

}
