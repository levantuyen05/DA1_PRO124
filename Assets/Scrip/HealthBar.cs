using UnityEngine;
using UnityEngine.UI;

public class Hearth : MonoBehaviour
{
    public Image healthBarFill;  // Image biểu diễn thanh máu
    public float maxHealth = 100f;  // Máu tối đa của nhân vật
    private float currentHealth;

    void Start()
    {
        // Thiết lập số máu ban đầu
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Điều chỉnh kích thước thanh máu dựa trên sức khỏe hiện tại
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }

    // Gọi hàm này để giảm máu
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
