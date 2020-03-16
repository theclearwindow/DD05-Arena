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
    public float health = 100;
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
    public void SetHealth(float newHealth)
    {
        //slider.value = playerScript.currentHealth;
        hp.fillAmount = newHealth/100;
        health = newHealth;
        
        Debug.Log(health);



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
