using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthScriptt : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public PlayerScript playerScript;
    public GameObject player;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void Update()
    {
        if(playerScript.currentHealth == 0)
        {
           // Destroy(this.gameObject);
            Debug.Log("Player dead");
            Destroy(player);
        }
    }
}
