using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 


public class Arvore : MonoBehaviour
{
    public int madeira=3;
    public int vida=3;
    public Inventario inventario;
   

    void ArvDerrubada() { 
 
        {
            inventario.QtdMadeira = inventario.QtdMadeira + madeira;
   
        }




    }

}
