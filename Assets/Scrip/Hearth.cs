using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBarFill;  // Image biểu diễn thanh máu
    public Vector3 offset = new Vector3(0, 2, 0);  // Độ lệch để thanh máu nằm trên nhân vật
    public float maxHealth = 100f;  // Máu tối đa của nhân vật
    private float currentHealth;

    void Start()
    {
        // Tìm đối tượng nhân vật chính trong cảnh với tag "Player"
        Transform player = GameObject.FindGameObjectWithTag("player").transform;
        if (player != null)
        {
            // Cập nhật vị trí thanh máu theo nhân vật
            transform.SetParent(player);
            transform.localPosition = offset;
        }

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

    // Xử lý va chạm với quái vật
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(5f);
        }
    }

   
}
