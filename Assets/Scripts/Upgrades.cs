using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : Interagivel
{
    void Start()
    {
        
    }

    public override void onCloseDistance() {
        if(Input.GetKeyDown(KeyCode.U)) {
            Debug.Log("Upgrades");
        }

    }
}
