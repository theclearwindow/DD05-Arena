using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float health = 1;
    public Transform me;
    public Transform hell;
    public Gradient gradient;
    public BaseAI playerScript;
    public GameObject player;
    public Image hp;
    public Image def;
    public Image spd;
    public Image dmg;
    public Slider slider;

    private float startTime;
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
        me = thisGuy.transform;
        startTime = Time.time;
        //hell.position = new Vector3(thisGuy.transform.position.x, -5, thisGuy.transform.position.z);
        float distToHell = Vector3.Distance(thisGuy.transform.position, hell.position);
       
        if (newHealth > 0)
        {
            hp.fillAmount = health;
            health = newHealth;

          

        }
        else
        {
            
            Debug.Log("TO HELL");
            

               /* float sunk = (Time.time - startTime) * 3;

                float fractionSunk = sunk / distToHell;

                me.position = Vector3.Lerp(thisGuy.transform.position, hell.position, fractionSunk);*///trying to Lerp
              // me.position = hell.position;//giving up on Lerp
               Destroy(thisGuy);
               Instantiate(thisGuy, hell.position, Quaternion.identity);




        }


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
