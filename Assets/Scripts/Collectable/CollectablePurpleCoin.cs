using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePurpleCoin : CollectableBase
{

    protected override void OnCollect()
    {
        base.OnCollect();
        CollectableManager.Instance.AddPurpleCoins();

    }
}
