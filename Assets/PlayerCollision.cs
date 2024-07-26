using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private HealthBar healthBar;

    void Start()
    {
        // Tìm đối tượng có tag "HealthBar" và lấy component HealthBar
        GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        if (healthBarObject != null)
        {
            healthBar = healthBarObject.GetComponent<HealthBar>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra xem đối tượng va chạm có tag "Enemy"
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (healthBar != null)
            {
                // Giảm máu của nhân vật mỗi lần va chạm
                healthBar.TakeDamage(5f);
            }
        }
    }
}
