using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : BaseAI
{

    public int power;
    private void OnTriggerEnter()
    {
        Destroy(this.gameObject);
        //Debug.Log("Hit");
        
    }
/*
    private IEnumerator damage()
    {

        yield return TakeDamage(power);
    }*/
}
