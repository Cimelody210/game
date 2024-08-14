using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleCollectable : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _shootSpeed;
    [SerializeField]
    private AudioClip pickupSound; // Âm thanh khi nhặt súng Rifle

    private AudioSource audioSource;
    private void Awake()
    {
        // Khởi tạo AudioSource
        audioSource = GetComponent<AudioSource>();
        
        audioSource = gameObject.AddComponent<AudioSource>();
        
    }
    public void OnCollected(GameObject player)
    {
        // Get the PlayerShoot component from the player GameObject
        PlayerShoot playerShoot = player.GetComponent<PlayerShoot>();

        if (playerShoot != null)
        {
            playerShoot.SetRifleProperties(0.07f, 40);
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
}

