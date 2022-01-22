using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendas : Interagivel
{
    void Start()
    {
        
    }

    public override void onCloseDistance() {
        if(Input.GetKeyDown(KeyCode.V)) {
            Debug.Log("Vendas");
        }
    }
}
