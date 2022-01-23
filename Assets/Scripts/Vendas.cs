using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendas : Interagivel
{
    public Inventario inventario;

    void Start()
    {
        
    }

    public override void onCloseDistance() {
        if(Input.GetKeyDown(KeyCode.V) && inventario.qtdMadeira > 0) {
            inventario.qtdMadeira -= 1;
            inventario.qtdDinheiro += 5;
        }
    }
}
