using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PS : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Vector2 moveInput;
    Animator anim;
    Rigidbody2D rb;
    private int current;
    public SpriteRenderer SR;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

    }


    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        print(moveInput.magnitude);

    }
    private void FixedUpdate()
    {
        rb.velocity = moveInput * speedMove * Time.deltaTime;
        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
                SR.transform.localScale = new Vector3(1, 1, 0);
            else SR.transform.localScale = new Vector3(-1, 1, 0);
        }
        PlayerAnimation();
    }

    public void PlayerAnimation()
    {
        anim.SetFloat("speed", moveInput.sqrMagnitude);
        Debug.Log("dmm");

    }
}
