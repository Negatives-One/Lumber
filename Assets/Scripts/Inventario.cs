using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventario : MonoBehaviour
{
    public TMP_Text UIText;

    public int qtdDinheiro = 0;
    public int qtdMadeira = 5;

    private void Update()
    {
        if(UIText)
        {
            UIText.SetText("Dinheiro: " + qtdDinheiro.ToString() + "\nMadeira: " + qtdMadeira.ToString());
        }
    }
}
