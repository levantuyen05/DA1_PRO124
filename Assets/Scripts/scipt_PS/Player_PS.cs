using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_PS : MonoBehaviour
{
    [SerializeField] private float speedMove;
    Vector2 moveInput;
    Animator anim;
    Rigidbody2D rb;
    private int current;
    //public SpriteRenderer SR;


    public CharacterDatabase characterDB;
   
    public SpriteRenderer spriteRenderer;

    private int selectedOption = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();


        if (!PlayerPrefs.HasKey("selectdOption"))
        {
            selectedOption = 0;
        }
        else
        {
            load();
        }
        UpdateCharacter(selectedOption);

    }

    private void UpdateCharacter(int selectedOption)
    {
        character Character = characterDB.GetCharacter(selectedOption);
        spriteRenderer.sprite = Character.characterSprite;
       
    }
    private void load()
    {
        selectedOption = PlayerPrefs.GetInt("selectdOption");
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
                spriteRenderer.transform.localScale = new Vector3(1, 1, 0);
            else spriteRenderer.transform.localScale = new Vector3(-1, 1, 0);
        }
        PlayerAnimation();
    }

    public void PlayerAnimation()
    {
        anim.SetFloat("speed", moveInput.sqrMagnitude);
        

    }
}
