using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public float dodgeSpeed = 5f; // Tốc độ né tránh
    public float dodgeCooldown = 2f; // Thời gian cooldown cho né tránh
    public float attackRange = 2f; // Phạm vi tấn công
    public float attackCooldown = 1f; // Thời gian cooldown cho chiêu phản công
    public Transform enemy; // Đối tượng kẻ thù

    private bool isDodging = false; // Trạng thái né tránh
    private bool isAttacking = false; // Trạng thái phản công
    private float dodgeTimer = 0f; // Thời gian đếm cooldown cho né tránh
    private float attackTimer = 0f; // Thời gian đếm cooldown cho phản công

    void Update()
    {
        // Nếu đang trong thời gian cooldown, giảm thời gian cooldown
        dodgeTimer -= Time.deltaTime;
        attackTimer -= Time.deltaTime;

        // Nếu nhân vật đang di chuyển chuột và chưa ở trong thời gian cooldown, thực hiện né tránh
        if (Input.GetMouseButtonDown(0) && !isDodging && dodgeTimer <= 0f)
        {
            Dodge();
        }

        // Nếu kẻ thù ở gần và chưa trong thời gian cooldown, thực hiện phản công
        if (Vector3.Distance(transform.position, enemy.position) <= attackRange && !isAttacking && attackTimer <= 0f)
        {
            Attack();
        }
    }

    void Dodge()
    {
        // Di chuyển ngẫu nhiên sang một hướng né tránh
        Vector3 dodgeDirection = Random.insideUnitSphere.normalized;
        dodgeDirection.y = 0; // Không di chuyển theo trục y
        Vector3 targetPosition = transform.position + dodgeDirection * dodgeSpeed;
        
        // Di chuyển nhân vật đến vị trí mới
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, dodgeSpeed * Time.deltaTime);
        
        // Đặt trạng thái né tránh và cooldown
        isDodging = true;
        dodgeTimer = dodgeCooldown;
    }

    void Attack()
    {
        // Thực hiện hành động phản công tại đây (ví dụ: gây sát thương cho kẻ thù)
        
        // Đặt trạng thái phản công và cooldown
        isAttacking = true;
        attackTimer = attackCooldown;
    }
}
