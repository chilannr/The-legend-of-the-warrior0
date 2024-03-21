using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public PlayerInputControls inputcontrtol;
    private PlayerAnimation playerAnimation;
    public Vector2 inputDirection;

    public Rigidbody2D rb;
    public PhysicsCheck physicsCheck;
    public CapsuleCollider2D coll;

    [Header("��������")]
    public float speed;
    public float jumpForce;
    public int maxJumpCount = 2; // �����Ծ����
    private int jumpCount; // ��ǰ��Ծ����

    [Header("�������")]
    public PhysicsMaterial2D wall;
    public PhysicsMaterial2D normal;

    [Header("״̬")]
    public bool isHurt;
    public float hurtForce;
    public bool isDead;
    public bool isAttack;
    
    private void Awake()
    {
        physicsCheck = GetComponent<PhysicsCheck>();
        rb = GetComponent<Rigidbody2D>();
        inputcontrtol = new PlayerInputControls();
        inputcontrtol.Gameplay.Jump.started += Jump;
        inputcontrtol.Gameplay.Attack.started += PlayerAttack;
        inputcontrtol.Gameplay.ESkill.started += PlayerAttack2;
        inputcontrtol.Gameplay.QSkill.started += PlayerAttack3;
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnable()
    {
        inputcontrtol.Enable();
    }
    private void OnDisable()
    {
        inputcontrtol.Disable();
    }
    private void Update()
    {
        inputDirection = inputcontrtol.Gameplay.Move.ReadValue<Vector2>();
       
        CheckState();


    }
    private void FixedUpdate()
    {
        if(!isHurt && !isAttack)
        Move();
    }

    //����
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);
    //}


  private void Move()
{
    // ����Ƿ���ǽ��Ӵ�
    bool isTouchingWall = physicsCheck.isTouchingWall;
    
    // �����ǽ��Ӵ������뷽����ǽ�淽����ͬ����ֹͣ�ƶ�
    if (isTouchingWall && Mathf.Sign(inputDirection.x) == Mathf.Sign(transform.localScale.x))
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        return;
    }

    // ���򣬸������뷽������ˮƽ�ٶ�
    rb.velocity = new Vector2(speed * Time.deltaTime * inputDirection.x, rb.velocity.y);

    // �������뷽�������ɫ����
    int faceDir = (int)transform.localScale.x;
    if (inputDirection.x > 0)
        faceDir = 1;
    if (inputDirection.x < 0)
        faceDir = -1;
    transform.localScale = new Vector3(faceDir, 1, 1);
}
    private void Jump(InputAction.CallbackContext obj)
    {
        // ����Ƿ��ڵ����ϣ����������Ծ
        if (physicsCheck.isGround)
        {
            jumpCount = 0; // ������Ծ����
            JumpAction();
            GetComponent<AudioDefination>()?.PlayAudioClip();
        }
        else if (jumpCount < maxJumpCount) // ������ڵ�������δ�ﵽ�����Ծ����������ж�����
        {
            JumpAction();
            GetComponent<AudioDefination>()?.PlayAudioClip2();
        }
    }
    private void JumpAction()
    {
        jumpCount++; // ������Ծ����
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }


    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;
        rb.AddForce(dir*hurtForce,ForceMode2D.Impulse);
    }
    public void PlayerDead()
    {
        isDead = true;
        inputcontrtol.Gameplay.Disable();

    }
    private void PlayerAttack(InputAction.CallbackContext obj)
    {
        playerAnimation.PlayerAttack();
        isAttack = true;
      
    }
    private void PlayerAttack2(InputAction.CallbackContext obj)
    {
        if (!isAttack)
        {
            playerAnimation.PlayerAttack2();
            isAttack = true;
        }

    }   
    private void PlayerAttack3(InputAction.CallbackContext obj)
    {
        if (!isAttack)
        {
            playerAnimation.PlayerAttack3();
            isAttack = true;
        }
    }
    private void CheckState()
    {
        coll.sharedMaterial = physicsCheck.isGround ? normal : wall;
    }
}
