using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float _speedRotate = 6.0f;
    public float _moveRotate = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x=Input.GetAxis("Horizontal")*_moveRotate*Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical")*_speedRotate*Time.deltaTime;
        transform.Translate(x,y,0);
        // transform.Rotate(0, 0, _speedRotate*Time.deltaTime);
    }
}
