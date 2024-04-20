using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 30;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity =  Vector2.right *speed;
    }

    // Update is called once per frame

    void Update()
    {
        
    }
    // Bước 11: Thêm code vào lớp Ball để giúp điều khiển khi quá banh va chạm với 2 vợt: 
    float  hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    void OnCollisionEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "RacketLeft")
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.GetComponent<Collider>().bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity =  dir * speed;
        }
        if (col.gameObject.name == "RacketLeft(1)")
        {
          
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.GetComponent<Collider>().bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }
    }

    private float hitfactor(Vector3 position1, Vector3 position2, object y)
    {
        throw new NotImplementedException();
    }
}
