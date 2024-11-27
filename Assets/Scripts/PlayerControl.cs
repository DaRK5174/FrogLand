using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float jumpfors;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }
        if (moveInput == 0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }

        Jump();

    }

     void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
      
          //  anim.SetTrigger("startGamp");

        if (isGrounded == true)
        {
           // anim.SetBool("isGamp", false);
        }
        else
        {
           // anim.SetBool("isGamp", true);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private bool jumpControle;
    private float jumpTime = 0;
    public float jumpControlTime = 0.7f;

    void Jump()
    {
         if (Input.GetKey(KeyCode.Space))
         {
            if(isGrounded == true)
            {
                jumpControle = true;
            }
         }
        else
        {
            jumpControle = false;
        }

         if(jumpControle== true)
        {  
            if((jumpTime += Time.deltaTime)< jumpControlTime)
            {
                rb.AddForce( Vector2.up * jumpfors / (jumpTime));
            }
        }
        else
        {
            jumpTime = 0;
        }
    }
}

