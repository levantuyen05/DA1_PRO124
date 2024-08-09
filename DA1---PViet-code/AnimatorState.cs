using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorState : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMove, verticalMove, 0);

        if (movement.magnitude > 0)
        {
            animator.SetBool("PlayrRun", true);
            transform.position += movement * speed * Time.deltaTime;

            // Flip sprite based on movement direction
            if (horizontalMove != 0)
            {
                spriteRenderer.flipX = horizontalMove < 0;
            }
        }
        else
        {
            animator.SetBool("PlayrRun", false);
        }
    }
}
