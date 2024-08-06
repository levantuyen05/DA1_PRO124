using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int minDamage = 10;
    public int maxDamage = 30;
    private int randomDamage;
    public GameObject damageTextPrefab;
    [SerializeField] float bulletSpeed = 10f;
    public float lifeTime;
    Rigidbody2D myRigidbody;
    private Vector3 targetPosition;
    float xSpeed;

    void OnEnable()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        xSpeed = bulletSpeed;
        randomDamage = Random.Range(minDamage, maxDamage + 1);
        Debug.Log(randomDamage);
    }
    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }
    void Update()
    {
        Vector2 direction = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }

    public void SetDirection(Vector2 direction)
    {
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                //int randomDamage = Random.Range(minDamage, maxDamage + 1);
                enemy.TakeDamage(randomDamage);
                ShowDamage(randomDamage, other.ClosestPoint(transform.position));
            }
            transform.position = other.ClosestPoint(transform.position);
            Destroy(gameObject);
        }
    }
    void ShowDamage(int damage, Vector3 position)
    {
        if (damageTextPrefab != null)
        {
            GameObject PopUp = Instantiate(damageTextPrefab, position, Quaternion.identity);
            TextMeshProUGUI Text = PopUp.GetComponentInChildren<TextMeshProUGUI>();
            if (Text != null)
            {
                Text.text = damage.ToString();
                Destroy(PopUp, 2f);
            }
        }
    }


}


