using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;  // Image biểu diễn thanh máu
    public Vector3 offset = new Vector3(0, 2, 0);  // Độ lệch để thanh máu nằm trên nhân vật
    private Transform player;  // Đối tượng nhân vật chính
    private float maxHealth = 100f;  // Máu tối đa của nhân vật
    private float currentHealth;

    void Start()
    {
        // Tìm đối tượng nhân vật chính trong cảnh với tag "Player"
        player = GameObject.FindGameObjectWithTag("player").transform;

        // Thiết lập số máu ban đầu
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (player != null)
        {
            // Cập nhật vị trí thanh máu theo nhân vật
            transform.position = player.position + offset;

            // Điều chỉnh kích thước thanh máu dựa trên sức khỏe hiện tại
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    // Gọi hàm này để giảm máu
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
