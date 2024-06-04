using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip mySoundClip; // Tham chiếu tới file âm thanh bạn muốn sử dụng

    private AudioSource audioSource;

    void Start()
    {
        // Tạo một AudioSource mới cho đối tượng này
        audioSource = gameObject.AddComponent<AudioSource>();

        // Gán âm thanh cho AudioSource
        audioSource.clip = mySoundClip;
    }

    public void PlaySound()
    {
        // Phát âm thanh
        audioSource.Play();
    }

    public void StopSound()
    {
        // Dừng âm thanh nếu đang phát
        audioSource.Stop();
    }
}
