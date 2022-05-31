using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerDeath = "Death";

    public HealthBase healthBase;

    private void Awake()
    {
        if(healthBase)
        {
            healthBase.onKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.onKill -= OnEnemyKill;

        DeathAnimation();
        Destroy(gameObject, 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();
        if(health != null)
        {
            health.Damage(damage);
            AttackAnimation();
        }
        
    }

    private void AttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }
     private void DeathAnimation()
    {
        animator.SetTrigger(triggerDeath);
    }

    public void Damage(int amount = 1)
    {
        healthBase.Damage(amount);
    }
}
