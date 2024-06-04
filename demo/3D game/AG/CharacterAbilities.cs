using UnityEngine;

public class CharacterAbilities : MonoBehaviour
{
    public float fireballCooldown = 2f; // Thời gian cooldown cho fireball
    private bool isFireballOnCooldown = false;

    public float dashCooldown = 5f; // Thời gian cooldown cho dash
    private bool isDashOnCooldown = false;

    public GameObject fireballPrefab; // Prefab của fireball
    public Transform firePoint; // Điểm bắn của fireball
    public float fireballSpeed = 10f;

    public float dashDistance = 5f; // Khoảng cách di chuyển của dash

    // Tốc độ di chuyển của nhân vật
    public float moveSpeed = 5f;

    void Update()
    {
        // Di chuyển nhân vật
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveInput * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q) && !isFireballOnCooldown)
        {
            LaunchFireball();
        }

        if (Input.GetKeyDown(KeyCode.E) && !isDashOnCooldown)
        {
            PerformDash();
        }
    }

    void LaunchFireball()
    {
        // Tạo một fireball từ prefab
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        
        // Di chuyển fireball
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * fireballSpeed;

        // Đặt fireball vào trạng thái cooldown và bắt đầu đếm thời gian
        isFireballOnCooldown = true;
        Invoke("ResetFireballCooldown", fireballCooldown);
    }

    void PerformDash()
    {
        // Di chuyển nhân vật theo hướng hiện tại
        transform.position += transform.right * dashDistance;

        // Đặt dash vào trạng thái cooldown và bắt đầu đếm thời gian
        isDashOnCooldown = true;
        Invoke("ResetDashCooldown", dashCooldown);
    }

    void ResetFireballCooldown()
    {
        isFireballOnCooldown = false;
    }

    void ResetDashCooldown()
    {
        isDashOnCooldown = false;
    }
}
