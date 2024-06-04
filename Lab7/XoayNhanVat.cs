using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Tốc độ xoay của nhân vật

    void Update()
    {
        // Lấy giá trị di chuyển của chuột
        float mouseX = Input.GetAxis("Mouse X");

        // Xoay nhân vật theo trục y
        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
    }
}
