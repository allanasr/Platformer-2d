using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;
    
    public string toggleActive = "Active";

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool(toggleActive, !animator.GetBool(toggleActive));
        }
    }
}
