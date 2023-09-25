using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    
    private float inputHorizontal;
    private bool facingRight = true;

    private Animator anim;
    private Rigidbody2D rb;
    private GroundCheck groundCheck;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheckCollider").GetComponent<GroundCheck>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("SpeedX", Mathf.Abs(inputHorizontal));
        anim.SetFloat("SpeedY", rb.velocity.y);
        anim.SetBool("isGrounded", groundCheck.isGrounded);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerAttack2")){
            if (inputHorizontal > 0 && !facingRight){
                Flip();
            } else if (inputHorizontal < 0 && facingRight){
                Flip();
            }
        }
    }

    
    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
