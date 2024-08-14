using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 1;
    public GameObject smokePrefab; // Prefab của Particle System khói
    private float maxY = -5;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < maxY)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ShipModel")
        {
            Smoke(); // Hiển thị hiệu ứng khói
            Game.GameOver();
            Destroy(gameObject);
        }
    }

    public void Smoke()
    {
        if (smokePrefab != null)
        {
            Instantiate(smokePrefab, transform.position, Quaternion.identity);
        }
    }
}
