using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : SaundCenter
{
    public float speed;
    public float jumpfors;
    private float moveInput;

    public Rigidbody2D rb;

    private bool facingRight = true;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;
    
    PlayerControl player;



    private bool danseYes;
    private void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        danseYes = false;

        if(isGrounded == true)
        {
            PlaySound(sounds[1]);
        }
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

        if (Input.GetKey(KeyCode.L))
        {
           
            if (danseYes == false)
            {
                danseYes = true;
                anim.SetBool("Danse", true);
            }
            else if(danseYes == true)
            {
                danseYes = false;
                anim.SetBool("Danse", false);
            }
        }
    }

     void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
              
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

    private bool setTriggerOn = true;
    void Jump()
    {
        
        if (isGrounded == true)
        {
            anim.SetBool("isJump", false);

        }
        else if(isGrounded == false && !Input.GetKey(KeyCode.Space))
        {          
            anim.SetBool("isJump", true);
           
        }      

        if (Input.GetKey(KeyCode.Space))
        {                              
            if (isGrounded == true)
            {
                if (setTriggerOn ==true)
                {
                    anim.SetTrigger("startJump");
                    jumpControle = true;
                    setTriggerOn = false;
                }
            }      
        }
        else
        {
            jumpControle = false;
            setTriggerOn = true;
        }

        if (jumpControle == true)
        { 
         
            if ((jumpTime += Time.deltaTime)< jumpControlTime)
            {                
                rb.AddForce( Vector2.up * jumpfors / (jumpTime*10));
            }
        }
        else
        {          
            jumpTime = 0;
           
        }

        
    }
    public void OffAnimationJump()
    {
        PlaySound(sounds[2]);

    }

    public void OnAnimationJump()
    {                     
        PlaySound(sounds[1]);
    }
     
    public void OnAnimationRun ()
    {
        PlaySound(sounds[0]);
    }
}

