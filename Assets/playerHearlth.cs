using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    int currentHealth;
    private HealthBar healthbar; // No need to be public since we'll assign it dynamically
    public UnityEvent OnDeath;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    private void Start()
    {
        // Find the HealthBar component dynamically
        healthbar = FindObjectOfType<HealthBar>();
        if (healthbar == null)
        {
            Debug.LogError("HealthBar not found in the scene.");
            return;
        }

        currentHealth = maxHealth;
        healthbar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        healthbar.UpdateBar(currentHealth, maxHealth);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("enemy"))
        {
            TakeDamage(1);
        }
    }
}
