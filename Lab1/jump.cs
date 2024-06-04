using UnityEngine;

public class JumpscareTrigger : MonoBehaviour
{
    public GameObject jumpscareImage;
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Đảm bảo rằng âm thanh chỉ được phát một lần
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            hasPlayed = true;
            
            // Hiển thị hình ảnh kinh dị (có thể là một hình ảnh sprite hoặc texture)
            jumpscareImage.SetActive(true);
            
            // Phát âm thanh jumpscare
            audioSource.Play();

            // Tạm dừng game hoặc thực hiện các hành động khác nếu cần
            Time.timeScale = 0f; // Tạm dừng thời gian trong game (không bắt buộc)
        }
    }
}
