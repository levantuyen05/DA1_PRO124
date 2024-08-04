using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public SpriteRenderer characterSR;
    Animator animator;

    public float dashBoost = 2f;
    private float dashTime;
    public float DashTime;
    private bool once;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Gun;
    [SerializeField] float atkSpeed, countDown = 0;
    public Vector3 moveInput;

    public GameObject damPopUp;
    //public LosePanel losePanel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        OnFire();
        /// Part 2
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += moveSpeed * Time.deltaTime * moveInput;
        //

        if (moveInput.x != 0)
        {
            // Tính toán góc quay dựa trên hướng di chuyển
            float targetAngle = moveInput.x > 0 ? 0f : 180f;

            // Xoay nhân vật tức thời
            transform.eulerAngles = new Vector3(0f, targetAngle, 0f);
        }

        // Kích hoạt Animator "Run" khi đang di chuyển ngang
        animator.SetBool("Speed", moveInput.x != 0);

        if (Input.GetKey(KeyCode.E) && dashTime <= 0)
        {
            animator.SetBool("Roll", true);
            moveSpeed += dashBoost;
            dashTime = DashTime;
            once = true;
        }

        if (dashTime <= 0 && once)
        {
            animator.SetBool("Roll", false);
            moveSpeed -= dashBoost;
            once = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0)) // Bắn đạn khi nhấn chuột trái
        {
            Shoot();
        }
    }

    //public void TakeDamageEffect(int damage)
    //{
    //    if (damPopUp != null)
    //    {
    //        GameObject instance = Instantiate(damPopUp, transform.position
    //                + new Vector3(UnityEngine.Random.Range(-0.3f, 0.3f), 0.5f, 0), Quaternion.identity);
    //        instance.GetComponentInChildren<TextMeshProUGUI>().text = damage.ToString();
    //        Animator animator = instance.GetComponentInChildren<Animator>();
    //        animator.Play("red");
    //    }
    //    if (GetComponent<Health>().isDead)
    //    {
    //        losePanel.Show();
    //    }
    //}
    void OnFire()
    {
        countDown -= Time.deltaTime;
        if (countDown > 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, Gun.position, transform.rotation);
            countDown = atkSpeed;
            Invoke("ResetAttackAnimation", 0.5f);

        }
    }
    void Shoot()
    {
        // Tính toán hướng từ nhân vật đến vị trí chuột
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;

        // Tạo viên đạn và xoay nó theo hướng chuột
        GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.SetTargetPosition(mousePosition); // Truyền vị trí mục tiêu cho viên đạn
        }
    }

}
