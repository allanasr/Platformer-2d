using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    public Animator playerAnimator;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(-0.5f, 0);
    public float speed;
    public float jumpForce = 2;
    public float runSpeed;

    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.5f;
    public float animationDuration = 0.5f;
    public Ease ease;

    [Header("Player Animation")]
    public string boolRun = "Run";
    public string boolDeath = "Death";
}
