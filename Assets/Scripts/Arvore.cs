using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arvore : MonoBehaviour
{
    private int madeira = 3;
    public int vida;
    static public int vidaMax = 3;
    public Inventario inventario;
    public Player player;

    public Solo solo;


    private void Start()
    {
        vida = vidaMax;
        player = GameObject.Find("Capsule").GetComponent<Player>();
        inventario = player.gameObject.GetComponent<Inventario>();
    }

    public void ArvDerrubada() 
    {
        inventario.qtdMadeira = inventario.qtdMadeira + madeira;
        Mapa a = GameObject.Find("Mapa").GetComponent<Mapa>();
        GameObject t = Instantiate(a.toco, transform.position, Quaternion.identity, GameObject.Find("Arvores").transform);
        t.GetComponent<Toco>().solo = solo;
        Destroy(gameObject);
    }

    public static void UpdateArvoreHealth()
    {
        vidaMax += 1;

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
