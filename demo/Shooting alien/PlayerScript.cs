using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript: MonoBehaviour
{
    public GameObject explosionSound;
    public GameObject damageEffect;
    public PlayerHealthBarScript playerHealthBar;
    public GameController gameController;
    public CoinCount coinCountScript;

    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip coinSound;

    public float speed =10f;
    public padding = 0.8f;
    float minX, maxX;
    float minY, maxY;
    
    public float health =20f;
    float barFillAmount = 1f;
    float damage =0;
    void FindBoundaries()
    {
        Camera gameCamera =  Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new vector3(0,0,0).x + padding);
        maxX = gameCamera.ViewportToWorldPoint(new vector3(1,0,0).x - padding);
        minY = gameCamera.ViewportToWorldPoint(new vector3(0,0,0).y + padding);
        maxY = gameCamera.ViewportToWorldPoint(new vector3(0,1,0).y - padding);
    }
    void Start()
    {
        FindBoundaries();
        damage =  barFillAmount / health;

    }
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
        float deltaY = Input.GetAxis("Vertical")*Time.deltaTime*speed;

        float newXpos =  Mathf.Clamp(transform.postition.x + deltaX.minX.maxX);
        float newYpos =  Mathf.Clamp(transform.postition.y, deltaY.minY.maxY);
        transform.position  = new Vector2(newXpos, newYpos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            DamagePlayerHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVfx  = Instantiate(damageEffect, collision.transform.position);
            Destroy(damageVfx, 0.05f);
            if(health < = 0)
            {
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);
                gameController.GameOver();
                Destroy(gameObject);
                GameObject blast =  Instantiate(explosionSound, transform.position, Quaternion identity);
                Destroy(blast,2f);
            }
        }
    }
}