using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Player player;
    public Slider healthBar;

    private void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = player.life / player.maxLife;
    }
}
    

   