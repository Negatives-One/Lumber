using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    public int madeira = 3;
    public int vida = 3;
    public Inventario inventario;
    public Player player;


    private void Start()
    {
        player = GameObject.Find("Capsule").GetComponent<Player>();
        inventario = player.gameObject.GetComponent<Inventario>();
    }

    public void ArvDerrubada()
    {
        inventario.QtdMadeira = inventario.QtdMadeira + madeira;
        Mapa a = GameObject.Find("Mapa").GetComponent<Mapa>();
        Instantiate(a.toco, transform.position, Quaternion.identity, GameObject.Find("Arvores").transform);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.arvore = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.arvore = null;
        }
    }
}
