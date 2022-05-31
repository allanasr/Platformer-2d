using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    public Color flashColor;
    public float duration = .1f;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();
        foreach(SpriteRenderer s in GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(s);
        }
    }

    public void Flash()
    {
        DOTween.Kill(gameObject);
        
        foreach(var s in spriteRenderers)
        {
            s.color = Color.white;
            s.DOColor(flashColor, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
