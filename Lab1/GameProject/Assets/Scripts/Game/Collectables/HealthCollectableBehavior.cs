using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectableBehavior : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _healthAmount;
    [SerializeField]
    private AudioClip pickupSound;

    private AudioSource audioSource;

    private void Awake()
    {
        // Khởi tạo AudioSource
        audioSource = GetComponent<AudioSource>();
        
        audioSource = gameObject.AddComponent<AudioSource>();
        
    }
    public void OnCollected(GameObject player)
    {
        player.GetComponent<HealthController>().AddHealth(_healthAmount);
        if (pickupSound != null)
        {
            audioSource.PlayOneShot(pickupSound);
        }
        else
        {
            Debug.LogWarning("khong co am thanh duoc gan");
        }
    }
}
