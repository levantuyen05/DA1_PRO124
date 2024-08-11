using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Slider healthSlider; // Slider thanh máu

    void Start()
    {
        // Tìm đối tượng thanh máu theo tag và lấy component Slider
        GameObject healthBar = GameObject.FindGameObjectWithTag("HealthBar");
        if (healthBar != null)
        {
            Debug.Log("HealthBar object found");
            healthSlider = healthBar.GetComponent<Slider>();
            if (healthSlider != null)
            {
                Debug.Log("Slider component found");
            }
            else
            {
                Debug.LogError("Slider component not found!");
            }
        }
        else
        {
            Debug.LogError("HealthBar object not found!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra va chạm với đối tượng có tag "Enemy"
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Collision with Enemy detected");
            if (healthSlider != null)
            {
                // Giảm giá trị của thanh máu đi 5
                healthSlider.value -= 5;
                Debug.Log("Health reduced by 5. Current health: " + healthSlider.value);
            }
            else
            {
                Debug.LogError("HealthSlider is null");
            }
        }
    }
}
