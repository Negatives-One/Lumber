using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    public int madeira=3;
    public int vida=3;
    public Inventario inventario;
    public Player player;
   
    void ArvDerrubada() { 
 
        {
            inventario.QtdMadeira = inventario.QtdMadeira + madeira;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            player.arvore = this; 
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject== player.gameObject)
        {
            player.arvore = null;
        }
    }
}
