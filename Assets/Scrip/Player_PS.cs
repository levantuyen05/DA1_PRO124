using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PS : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Vector2 moveIput;
    Animator anim;
    Rigidbody2D rb;
    private int current;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        moveIput.x = Input.GetAxisRaw("Horizontal");
        moveIput.y = Input.GetAxisRaw("Vertical");
        moveIput.Normalize();
        print(moveIput.magnitude);
        PlayerAnimation();
    }
    private void FixedUpdate()
    {
        rb.velocity = moveIput * speedMove * Time.deltaTime;
    }

    public void PlayerAnimation()
    {
        if (rb.velocity.magnitude > 0 )
        {
            if (moveIput.x > 0 && moveIput.y == 0) { anim.Play("player_walk"); current = 1; }
            if (moveIput.x <0 && moveIput.y == 0) { anim.Play("player_walk_trái"); current = 2; }
        }
        else
        {
            switch (current)
            {
                case 1: anim.Play("player_idle"); break;
                case 2:

                    if (moveIput.x != 0)
                    {
                        if (moveIput.x > 0)
                            transform.localScale = new Vector3(0.3f, 0.3f, 0);
                        else transform.localScale = new Vector3(-0.3f, 0.3f, 0);
                    };
                    break;
            }
        }
    }
}
