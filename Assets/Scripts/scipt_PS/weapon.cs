using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeFire = 0.5f;
    public float bulletForce;

    private float timeBtwFire;


    public WeaponManager_PS weaponManager_PS;
    void Start()
    {
        weaponManager_PS = FindObjectOfType<WeaponManager_PS>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();

        timeBtwFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBtwFire < 0)
        {
            FireBullet();
        }
    }
    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(0, 1, 0);
        }

    }
    void FireBullet()
    {
       

        timeBtwFire = TimeFire;
        GameObject bl = Instantiate(bullet,firePos.position, Quaternion.identity);
        Rigidbody2D rb = bl.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
