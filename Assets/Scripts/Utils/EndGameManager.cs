using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public AudioSource audioSource;

    public GameObject winScreen;

    public GameObject EndGameTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            audioSource.Play();
            winScreen.SetActive(true);
        }
    }
}
