using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife;

    public bool destroyOnKill = false;

    private int currentLife;

    private bool isDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        currentLife = startLife;
        isDead = false;

    }
    public void Damage(int damage)
    {
        currentLife -= damage;

        if(currentLife <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        if(destroyOnKill)
        {
            Destroy(gameObject);
        }

        isDead = true;
    }
}
