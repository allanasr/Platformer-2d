using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public Action onKill;

    public FlashColor flashColor; 

    public int startLife;

    public bool destroyOnKill = false;

    private int currentLife;

    private bool isDead = false;

    private void Awake()
    {
        Init();

        if(!flashColor)
        {
            flashColor = GetComponent<FlashColor>();
        }
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
        else
        {
            flashColor.Flash();
        }
    }

    private void Kill()
    {
        if(destroyOnKill)
        {
            Destroy(gameObject);
        }

        onKill?.Invoke();

        isDead = true;
    }
}
