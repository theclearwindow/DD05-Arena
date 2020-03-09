using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float fillPer;
    public float health;
    public Gradient gradient;
    public MaxAI playerScript;
    public GameObject player;
    public Image hp;
    public Image def;
    public Image spd;
    public Image dmg;
    public Slider slider;
    //public GameObject player;
    private void Start()
    {
        health = GetComponentInParent<MaxAI>().maxHealth;
    }

//    public void SetMaxHealth(float health)
//    {
//        slider.maxValue = health;
//        slider.value = health;
//        
//        
//    }
    public void SetHealth(float health)
    {
        //slider.value = playerScript.currentHealth;
        hp.fillAmount = health/100;
        Debug.Log(health);



    }

    public void StatBars(Mode newMode)
    {
        spd.fillAmount = newMode.SPercent;
        def.fillAmount = newMode.HPercent;
        dmg.fillAmount = newMode.DPercent;


    }
    public void Update()
    {
        
        
        
        if (playerScript != null)
        {

            //health = playerScript.currentHealth;
            //this.GetComponent<Image>().fillAmount = health/100;
            
            
            if (playerScript.currentHealth <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Player dead");
                //Destroy(player);
            }
        }
    }
}
