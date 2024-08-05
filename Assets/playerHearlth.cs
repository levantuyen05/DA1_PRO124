using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public string healthBarName = "HealthBar";  // Tên của đối tượng Slider trong scene
    private Slider healthBar;  // Tham chiếu đến Slider thanh máu
    public float currentHealth = 100f;  // Giá trị máu hiện tại
    public float maxHealth = 100f;  // Giá trị máu tối đa
    private float damage = 5f;  // Lượng máu bị trừ khi bấm Space

    void Start()
    {
        // Tìm đối tượng Slider theo tên và lấy component Slider
        GameObject healthBarObject = GameObject.Find(healthBarName);
        if (healthBarObject != null)
        {
            healthBar = healthBarObject.GetComponent<Slider>();
        }
        else
        {
            Debug.LogError("HealthBar object not found!");
        }

        // Đảm bảo thanh máu bắt đầu ở giá trị tối đa
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra va chạm với kẻ thù
        if (collision.gameObject.tag == "enemy")
        {
            TakeDamage(damage);
        }
    }

    void TakeDamage(float amount)
    {
        // Giảm máu hiện tại và đảm bảo không dưới 0
        currentHealth = Mathf.Max(currentHealth - amount, 0f);

        // Cập nhật giá trị của thanh máu nếu Slider đã được tìm thấy
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        // Kiểm tra nếu máu giảm về 0 thì nhân vật chết
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Xử lý khi nhân vật chết, ví dụ: hiển thị màn hình game over
        Debug.Log("Player has died!");
        // Các mã lệnh khác để xử lý khi nhân vật chết
    }
}
