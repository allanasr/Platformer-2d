using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;
    public HealthBase healthBase;

    public SOPlayer soPlayer;


    private float _currentSpeed;

    private Animator currentPlayerAnimator;


    private void Awake()
    {
        if (healthBase)
        {
            healthBase.onKill += OnPlayerKill;
        }

        currentPlayerAnimator = Instantiate(soPlayer.playerAnimator, transform);
    }
    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void OnPlayerKill()
    {
        healthBase.onKill -= OnPlayerKill;

        currentPlayerAnimator.SetTrigger(soPlayer.boolDeath);
        Destroy(gameObject, 1f);
    }
    private void HandleMovement()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayer.runSpeed;
            currentPlayerAnimator.speed = 2;
        }
        else
        {
            _currentSpeed = soPlayer.speed;
            currentPlayerAnimator.speed = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentPlayerAnimator.SetBool(soPlayer.boolRun, true);
            myRigidBody2D.velocity = new Vector2(-_currentSpeed, myRigidBody2D.velocity.y);
            if (myRigidBody2D.transform.localScale.x != -1)
            {
                myRigidBody2D.transform.DOScaleX(-1, 0.2f);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentPlayerAnimator.SetBool(soPlayer.boolRun, true);
            myRigidBody2D.velocity = new Vector2(_currentSpeed, myRigidBody2D.velocity.y);
            if (myRigidBody2D.transform.localScale.x != 1)
            {
                myRigidBody2D.transform.DOScaleX(1, 0.2f);
            }
        }
        else
        {
            currentPlayerAnimator.SetBool(soPlayer.boolRun, false);
        }

        if (myRigidBody2D.velocity.x > 0)
        {
            myRigidBody2D.velocity -= soPlayer.friction;
        }

        else if (myRigidBody2D.velocity.x < 0)
        {
            myRigidBody2D.velocity += soPlayer.friction;
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = Vector2.up * soPlayer.jumpForce;
            myRigidBody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody2D.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody2D.transform.DOScaleY(soPlayer.jumpScaleY, soPlayer.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
        myRigidBody2D.transform.DOScaleX(soPlayer.jumpScaleX, soPlayer.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
