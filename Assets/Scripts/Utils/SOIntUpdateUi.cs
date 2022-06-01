using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOIntUpdateUi : MonoBehaviour
{
    public SOInt soInt;
    public TMP_Text tmpObject;

    public void Start()
    {
        tmpObject.text = soInt.value.ToString();
    }

    private void Update()
    {
        tmpObject.text = soInt.value.ToString();
    }

}
