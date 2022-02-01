using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : Interagivel
{
    public override void onCloseDistance()
    {
        if (Input.GetKeyDown(KeyCode.U) && inventario.qtdDinheiro >= 20)
        {
            inventario.qtdDinheiro -= 20;
            player.force += 1;
            Debug.Log(player.force);
        }

    }
}
