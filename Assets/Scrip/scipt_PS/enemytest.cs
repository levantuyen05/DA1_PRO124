using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemytest : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float followDistance = 10f;
    public float attackDistance = 2f;
    public float attackCooldown = 1f;
    private float nextAttackTime;

    Rigidbody2D rb;
    PlayerHealthh PLhealth;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= followDistance)
        {
            FollowPlayer(distanceToPlayer);

            if (distanceToPlayer <= attackDistance && Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
    void FollowPlayer(float distanceToPlayer)
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void AttackPlayer()
    {
        // Gọi phương thức tấn công hoặc giảm máu của nhân vật tại đây
        Debug.Log("Tấn công nhân vật!");
        // Ví dụ:
         player.GetComponent<PlayerHealthh>().TakeDamage(1);
    }
}
