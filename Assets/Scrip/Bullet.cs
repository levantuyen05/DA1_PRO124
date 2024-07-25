using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public int minDamage = 0;
    public int maxDamage = 0;
    [SerializeField] float bulletSpeed = 10f;
    public float lifeTime;
    Rigidbody2D myRigidbody;
    private Vector3 targetPosition;
    float xSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        xSpeed = bulletSpeed;
    }
    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }
    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
        Destroy(gameObject, lifeTime);
        Vector2 direction = (targetPosition - transform.position).normalized;

        // Xoay viên đạn theo hướng mới
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        // Di chuyển viên đạn theo hướng mới
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector2 direction)
    {
        // Chuẩn hóa vector hướng để có độ dài bằng 1
        direction.Normalize();

        // Tính toán góc quay từ vector hướng
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        // Di chuyển viên đạn theo hướng chuột
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            int damage = Random.Range(minDamage, maxDamage);
            //collision.GetComponent<Health>().TakeDam(damage);
            //collision.GetComponent<EnemyController>().TakeDamEffect(damage);
            Destroy(gameObject);
        }
    }
}


