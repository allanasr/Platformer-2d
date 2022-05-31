using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using TMPro;
public class CollectableManager : Singleton<CollectableManager>
{
    public int coins;

    public TMP_Text textAmount;

    private void Start()
    {

        coins = 0;

    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        textAmount.text = coins.ToString();
    }

}
