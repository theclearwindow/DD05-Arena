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

    public void SetNewMode(Mode newMode)
    {

        HP = R * newMode.HPercent;
        SPD = R * newMode.SPercent;
        DMG = R * newMode.DPercent;

        
        
    }
    
//    public void SetAI(BaseAI _ai) {
//        ai = _ai;
//        ai.Stats = this;
//    }
}
