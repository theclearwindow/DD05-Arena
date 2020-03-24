using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public int power;
    //public float speed = 5;
    //private Rigidbody rb;

    private void Start()
    {

        //set power equal to 10 * the mod of the AI who fired it
        //for now bullet power is unaffected by damage
        //rb = GetComponent<Rigidbody>();
        //rb.AddForce(-transform.up * speed);
    }

    private void Update()
    {
        //transform.position += -transform.up * Time.deltaTime * speed;
        //transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
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
