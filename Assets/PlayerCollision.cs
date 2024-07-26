using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra xem đối tượng va chạm có tag "enemy"
        if (collision.gameObject.CompareTag("enemy"))
        {
            // Tìm đối tượng có tag "HealthBar" trong cảnh
            GameObject healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");

            if (healthBarObject != null)
            {
                // Lấy component HealthBar từ đối tượng tìm thấy
                HealthBar healthBar = healthBarObject.GetComponent<HealthBar>();

                if (healthBar != null)
                {
                    // Giảm máu của nhân vật mỗi lần va chạm
                    healthBar.TakeDamage(5f);
                }
            }
        }
    }
}
