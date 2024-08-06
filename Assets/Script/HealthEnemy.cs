using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int damage = 10; // Sát thương enemy gây ra cho Player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Lấy component PlayerHealth từ Player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            // Kiểm tra nếu component PlayerHealth tồn tại
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Gọi hàm TakeDamage để trừ máu
            }
        }
    }
}
