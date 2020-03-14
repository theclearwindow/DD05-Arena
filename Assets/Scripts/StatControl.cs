using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatControl 
{
    //private BaseAI ai = null;
    public float HP {  get; private set; }
    public float R { get; private set; }
    public float SPD { get; private set; }
    public float DMG { get; private set; }   

    //public HealthScript healthScript;
    
    
//adjust total resource value and set it.
    public void SetHealth(float newHealth)
    {
        //set R as player current health
        R = newHealth;
    }

    public void SetNewMode(float[] newMode)
    {
        HP = R * newMode[0];
        SPD = R * newMode[1];
        DMG = R * newMode[2];
    
    }
    
//    public void SetAI(BaseAI _ai) {
//        ai = _ai;
//        ai.Stats = this;
//    }
}
