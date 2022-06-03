using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;

    public float side = 1;

    public int damageAmount = 1;

    public float timeToDestroy = 2f;
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if(enemy)
        {
            enemy.Damage(damageAmount);
            Destroy(gameObject);
        }
    }
}
