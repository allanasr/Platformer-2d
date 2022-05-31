using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    public HealthBase healthBase;

    public Vector2 friction = new Vector2(-0.5f, 0);

    [Header("Speed setup")]
    public float speed;
    public float jumpForce = 2;
    public float runSpeed;

    private float _currentSpeed;
    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.5f;
    public float animationDuration = 0.5f;
    public Ease ease;

    [Header("Player Animation")]
    public Animator animator;
    public string boolRun = "Run";
    public string boolDeath = "Death";


    private void Awake()
    {
        if (healthBase)
        {
            healthBase.onKill += OnPlayerKill;
        }
    }
    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void OnPlayerKill()
    {
        healthBase.onKill -= OnPlayerKill;

        animator.SetTrigger(boolDeath);
        Destroy(gameObject, 1f);
    }
    private void HandleMovement()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = runSpeed;
            animator.speed = 2;
        }
        else
        {
            _currentSpeed = speed;
            animator.speed = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool(boolRun, true);
            myRigidBody2D.velocity = new Vector2(-_currentSpeed, myRigidBody2D.velocity.y);
            if (myRigidBody2D.transform.localScale.x != -1)
            {
                myRigidBody2D.transform.DOScaleX(-1, 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool(boolRun, true);
            myRigidBody2D.velocity = new Vector2(_currentSpeed, myRigidBody2D.velocity.y);
            if (myRigidBody2D.transform.localScale.x != 1)
            {
                myRigidBody2D.transform.DOScaleX(1, 0.2f);
            }
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        if (myRigidBody2D.velocity.x > 0)
        {
            myRigidBody2D.velocity -= friction;
        }

        else if (myRigidBody2D.velocity.x < 0)
        {
            myRigidBody2D.velocity += friction;
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = Vector2.up * jumpForce;
            myRigidBody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody2D.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigidBody2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
