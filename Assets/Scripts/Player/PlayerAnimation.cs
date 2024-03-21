using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck PhysicsCheck;
    private PlayerController playerController;
    
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PhysicsCheck = GetComponent<PhysicsCheck>();
        playerController = GetComponent<PlayerController>();
        

    }
    private void Update()
    {
        setAnimation();
    }

    private void setAnimation()
    {
        anim.SetFloat("velocityX",MathF.Abs(rb.velocity.x));
        anim.SetFloat("velocityY",rb.velocity.y);
        anim.SetBool("isGround", PhysicsCheck.isGround);
        anim.SetBool("isDead",playerController.isDead );
        anim.SetBool("isAttack",playerController.isAttack);
        

    }
    public void PlayHurt()
    {
        anim.SetTrigger("hurt");
    }
    public void PlayerAttack()
    {
        
        anim.SetTrigger("attack");
        
    }

    public void PlayerAttack2()
    {
        anim.SetTrigger("eskill");
    }

    internal void PlayerAttack3()
    {
        anim.SetTrigger("qskill");
    }
}
