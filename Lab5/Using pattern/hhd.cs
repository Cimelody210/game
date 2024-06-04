using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemyFactory enemyFactory;

    void Start()
    {
        // Sử dụng Singleton Pattern
        SoundManager.Instance.PlaySound("BackgroundMusic");

        // Sử dụng Factory Pattern
        GameObject enemy = enemyFactory.CreateEnemy(new Vector3(0, 0, 0));
        // Tùy chỉnh các thuộc tính của enemy nếu cần
    }
}
