using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public float speed = 5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        // Flip sprite based on horizontal movement
        if (horizontalMove != 0)
        {
            spriteRenderer.flipX = horizontalMove < 0;
        }

        // Update position based on input
        transform.position += new Vector3(horizontalMove * speed * Time.deltaTime, verticalMove * speed * Time.deltaTime, 0);
    }
}