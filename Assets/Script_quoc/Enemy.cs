using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 5f; 
    private float originalMoveSpeed;
    public float maxHealth = 100f; 
    private float currentHealth; 
    public int expReward = 10; 

    void Start()
    {
        currentHealth = maxHealth;
        originalMoveSpeed = moveSpeed;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                PlayerExp playerExp = playerObject.GetComponent<PlayerExp>();
                if (playerExp != null)
                {
                    playerExp.UpdateExperience(expReward);
                }
            }
            Destroy(gameObject);
    }
    public void FreezeEnemy()
    {
        
        moveSpeed = 0;
        Invoke("UnfreezeEnemy", 0.2f);
    }

    private void UnfreezeEnemy()
    {
        moveSpeed = originalMoveSpeed;
    }
}
