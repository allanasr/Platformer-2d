using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }
    protected virtual void OnCollect()
    {

    }
}
