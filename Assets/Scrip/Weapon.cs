using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire;
   // public GameObject muzzle;
    

    void Update()
    {
        RotateGun();
        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeBtwFire < 0) 
        {
            FireBullet();
        }
    }
    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion  rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            // Flip the object by rotating it 180 degrees around the x-axis
            transform.rotation = Quaternion.Euler(180f, 0f, -transform.eulerAngles.z);
        }
        else
        {
            // Ensure the object is in its normal orientation
            transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z);
        }
    }
     void FireBullet()
    {
        timeBtwFire = timeBtwFire;

        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        //effect
       //Instantiate(muzzle, firePos.position, transform.rotation, transform);


        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject); // Quái biến mất

        
            Destroy(gameObject); // Đạn cũng biến mất
        }
    }
   
}
