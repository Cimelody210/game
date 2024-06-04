using UnityEngine;


public class NuclearExplosion : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    public Light explosionLight;

    void Start()
    {
        // Kích hoạt Particle System và ánh sáng
        explosionParticles.Play();
        explosionLight.enabled = true;

        // Tự động tắt hiệu ứng sau một khoảng thời gian
        Invoke("TurnOffEffect", 3f);
    }

    void TurnOffEffect()
    {
        // Tắt Particle System và ánh sáng
        explosionParticles.Stop();
        explosionLight.enabled = false;

        // Hủy đối tượng hiệu ứng sau một thời gian ngắn để giải phóng tài nguyên
        Destroy(gameObject, 2f);
    }
}
