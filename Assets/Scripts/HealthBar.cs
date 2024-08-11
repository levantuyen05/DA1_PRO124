using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Image healthBarFill;  // Ảnh biểu diễn thanh máu
    public float maxHealth = 100f;  // Máu tối đa của nhân vật
    private float currentHealth;

    void Start()
    {
        // Thiết lập số máu ban đầu
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Gọi hàm này để giảm máu
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    // Cập nhật hiển thị thanh máu
    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

}
