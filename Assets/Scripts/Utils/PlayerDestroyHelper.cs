using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;
    public void KillPlayer()
    {
        if(player)
            player.DestroyMe();
        SceneManager.LoadScene(1);

    }
}
