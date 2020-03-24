using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
   public float health = 1;
    public Gradient gradient;
    public BaseAI playerScript;
    public GameObject player;
    public Image hp;
    public Image def;
    public Image spd;
    public Image dmg;
    public Slider slider;
    //public GameObject player;
    private void Start()
    {
        //health = GetComponentInParent<BaseAI>().GetHealth();//damage functions must first set health in healthscript
    }

    private void update()
    {
        
        
        
    }

//    public void SetMaxHealth(float health)
//    {
//        slider.maxValue = health;
//        slider.value = health;
//        
//        
//    }
    public void SetHealth(float newHealth, GameObject thisGuy)
    {
        //slider.value = playerScript.currentHealth;
        if (newHealth > 0)
        {
            hp.fillAmount = health;
            health = newHealth;

          

        } else Destroy(thisGuy);

        Debug.Log("Health: " + health);
       // Debug.Log("fill amount: " + hp.fillAmount);

    }

    public void StatBars(float[] newMode)
    {
        spd.fillAmount = newMode[0];
        def.fillAmount = newMode[1];
        dmg.fillAmount = newMode[2];


    }
    public void Update()
    {
        
        
        
        
    }
}
