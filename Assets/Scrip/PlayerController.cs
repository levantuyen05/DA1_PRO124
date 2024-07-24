using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public  Animator animator; 
    private Rigidbody2D rb;
    public Vector3 moveInput;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        if (moveInput.x != 0)
        {
            float rotationAngle = (moveInput.x > 0) ? 0f : 180f;
            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}
    