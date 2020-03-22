using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : BaseAI
{

    public int power;

    private void Start()
    {
        
        //set power equal to 10 * the mod of the AI who fired it
        //for now bullet power is unaffected by damage
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
        Debug.Log("Hit");
        
    }
/*
    private IEnumerator damage()
    {

        yield return TakeDamage(power);
    }*/
}
