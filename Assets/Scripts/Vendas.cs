using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendas : Interagivel
{
    public override void OnCloseDistance()
    {
        if (Input.GetKeyDown(KeyCode.V) && inventario.qtdMadeira > 0)
        {
            inventario.qtdMadeira -= 1;
            inventario.qtdDinheiro += 5;
        }
    }
}
