using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_PS : MonoBehaviour
{
    public int minDamage = 6;
    public int maxDamage = 16;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            int damage = Random.Range(minDamage, maxDamage);
            collision.GetComponent<PlayerHealthh>().TakeDamage(damage);
            
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
