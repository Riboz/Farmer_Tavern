using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int speed;
    private string currentState;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(horizontalInput , verticalInput ).normalized*speed;

        if(horizontalInput != 0 || verticalInput != 0)
        {
         StateMachine("Player_Walk");

        } 
        else if(horizontalInput == 0 && verticalInput == 0)
        {
            StateMachine("Player_idle");
        }

        if(horizontalInput < 0)
        {
            GetComponent<SpriteRenderer>().flipX=true;
        }

        else if(horizontalInput > 0)
        {
            GetComponent<SpriteRenderer>().flipX=false;
        }

    }
    void StateMachine(string newState)
    {
        if(currentState==newState)
        {
            return;
        }
        else
        {
            currentState=newState;
            anim.Play(currentState);
        }
    }
}
