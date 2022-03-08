using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody2D;

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

    void Update()
    {
        HandleJump();
        HandleMovement();
    }

    private void HandleMovement()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = runSpeed;
        }
        else
        {
            _currentSpeed = speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            myRigidBody2D.velocity = new Vector2(-_currentSpeed, myRigidBody2D.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            myRigidBody2D.velocity = new Vector2(_currentSpeed, myRigidBody2D.velocity.y);
        }

        if (myRigidBody2D.velocity.x > 0)
        {
            myRigidBody2D.velocity -= friction;
        }

        else if( myRigidBody2D.velocity.x < 0)
        {
            myRigidBody2D.velocity += friction;
        }

    }

    private void HandleJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = Vector2.up * jumpForce;
            myRigidBody2D.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody2D.transform);
         
            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody2D.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myRigidBody2D.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
    }

}
