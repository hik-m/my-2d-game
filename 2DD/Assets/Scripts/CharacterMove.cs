using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CharacterMove : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float maxSpeed;
    public float jumpPower;
    private int jumpCount = 0;
    public int doubleJumpCount;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

    }
    void Update()
    {
        
        


        //stop speed





        




    }

    // Update is called once per frame
     public void Fall()
    {

        if (rigid.velocity.y < 0)
        {
            
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            anim.SetBool("IsJump", false);
            anim.SetBool("IsFall", true);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1.7f)
                {
                    anim.SetBool("IsFall", false);
                    jumpCount = 0;
                }

            }
        }

    }

    public void RightMove()
    {

        //move by key controll

        
        Debug.DrawRay(rigid.position, Vector3.right, Color.red);
        RaycastHit2D rightHit = Physics2D.Raycast(rigid.position, Vector3.right, 0.5f, LayerMask.GetMask("Platform"));
        

        if (!rightHit)
        {
            rigid.position += new Vector2(10 * Time.deltaTime, 0);
            anim.SetBool("IsWalk", true);
            spriteRenderer.flipX = false;

        }
        





        Debug.Log(rightHit);

    }
    public void LeftMove()
    {
        Debug.DrawRay(rigid.position, Vector3.left, Color.red);
        RaycastHit2D lefttHit = Physics2D.Raycast(rigid.position, Vector3.left, 0.5f, LayerMask.GetMask("Platform"));

        if ( !lefttHit)
        {
            rigid.position += new Vector2(-10 * Time.deltaTime, 0);
            anim.SetBool("IsWalk", true);
            spriteRenderer.flipX = true;
        }
        
    }

    public void IDLSet()
    {
        anim.SetBool("IsWalk", false);
    }



    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < doubleJumpCount)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("IsJump", true);
            jumpCount += 1;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("2");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("1");

    }


}