using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : Interagivel
{
    public GameObject panel;
    public override void onCloseDistance()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Camera.main.GetComponent<SC_CameraCollision>().LockMouse(false);
            panel.SetActive(true);
        }
    }

    public void SellForce()
    {
        if(inventario.qtdDinheiro >= 20)
        {
            inventario.qtdDinheiro -= 20;
            player.force += 1;
        }
    }

    public void SellHeal()
    {
        if(inventario.qtdDinheiro >= 20)
        {
            inventario.qtdDinheiro -= 20;
            player.life = player.maxLife;
        }
    }
}
