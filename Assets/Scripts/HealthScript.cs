using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float fillPer;
    public float health;
    public Gradient gradient;
    public MaxAI playerScript;
    //public GameObject player;

    public void SetMaxHealth(float health)
    {
        //slider.maxValue = health;
        //slider.value = health;
    }
    public void SetHealth(float health)
    {
        //slider.value = health;
        health = GetComponentInParent<MaxAI>().maxHealth;
        fillPer = GetComponent<Image>().fillAmount;

    }
    public void Update()
    {
        if (playerScript != null)
        {

            health = playerScript.currentHealth;
            fillPer = health/100;
            
            if (playerScript.currentHealth == 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Player dead");
                //Destroy(player);
            }
        }
    }
}
