using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    public GameObject Projectile_Emitter;
    public GameObject Projectile_Default;

    public float Projectile_Forward_Force = 600;
    public float fireRateDefault = 0.5f;

    private float timer;
    private bool shotFired = false;
    private bool weaponDefault = true;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (weaponDefault == true)
        {
            timer += Time.deltaTime;
            if (timer > fireRateDefault)
            {
                if (shotFired == false)
                {
                    
                    GameObject Projectile_Handler;

                    Projectile_Handler = Instantiate(Projectile_Default, Projectile_Emitter.transform.position, Projectile_Emitter.transform.rotation) as GameObject;
                    Projectile_Handler.transform.Rotate(Vector3.left * 90);

                    Rigidbody Projectile_RigidBody;
                    Projectile_RigidBody = Projectile_Handler.GetComponent<Rigidbody>();

                    Projectile_RigidBody.AddForce(transform.forward * Projectile_Forward_Force);

                    shotFired = true;
                    timer = 0;
                    shotFired = false;


                    //weaponDefault = false;

                    Destroy(Projectile_Handler, 3.0f);
                }
            }
        }
    }
}
