using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class UnitController : MonoBehaviour
{
    
    public int maxHealth = 100;
    public float currentHealth;
    public float defense;
    public float speed;
    public float damage;

    public SoundControl sounds;
    //public GameObject BulletPrefab = null;
    public Transform BulletSpawnPoint = null;
    public Transform hellPlane;
    public HealthScript healthScript;
    public StatControl Stats;
    private BaseAI ai = null;
    //=============Field of View=============
    private GameObject seenTarget = null;
    //private bool scan = true;
    //==========Shooting stuff===============
    public GameObject Projectile_Emitter;
    public GameObject Projectile_Prefab;
    public GameObject MySelf;

    public float Projectile_Forward_Force = 600;
    public float fireRateDefault = 0.5f;

    private float timer;
    private bool shotFired = false;
    private bool weaponDefault = true;
    //==========================================

    //AI navmesh stuff
    public GameObject navTarget = null;
    public UnityEngine.AI.NavMeshAgent agent;

    private float baseSpeed = 2.0f; // values may change, but these will be what all stats are based on
    private float rotationSpeed = 180.0f; // values may change, but these will be what all stats are based on
    private float mapSize = 500.0f;

    public AItype _AItype;

    private void Start()
    {
        if (_AItype == AItype.Max)
        {
            SetAI(new MaxAI());
            StartBattle();
        }
        else if (_AItype == AItype.Jorn)
        {
            SetAI(new CopyPasteAI());
            StartBattle();
        }
        else if (_AItype == AItype.Omar)
        {
            SetAI(new CopyPasteAI());
            StartBattle();
        }
        else if (_AItype == AItype.Michael)
        {
            SetAI(new MaxAI());
            StartBattle();
        }
        else if (_AItype == AItype.Sofie)
        {
            SetAI(new MaxAI());
            StartBattle();
        }
        else if (_AItype == AItype.Theo)
        {
            SetAI(new MaxAI());
            StartBattle();
        }
        else
        {
            SetAI(new CopyPasteAI());
            StartBattle();
        }

        currentHealth = 100;
        //seenTarget = GetComponent<FieldOfView>().theTarget;
        //Debug.Log(seenTarget);
    }

    private void OnDestroy()
    {
        if (FindObjectOfType<CameraFollow>() != null) {
        FindObjectOfType<CameraFollow>().others.Remove(this.gameObject);
        }
        
    }

    private void Update()
    {
        if (currentHealth > 0)
        {


            timer += Time.deltaTime; //Timer counting up for shooting.

            //Updating every step what it's target is.
            seenTarget = GetComponent<FieldOfView>().theTarget;
            navTarget = seenTarget;
            //Debug.Log(seenTarget);

            Debug.DrawRay(transform.position, transform.forward, Color.green, 1.0f);
        }
    }
    public void SetAI(BaseAI _ai)
    {
        ai = _ai;
        ai.Unit = this;
    }

    public void StartBattle()
    {
        //if (currentHealth > 0)
        //{

            StartCoroutine(ai.RunAI());
            
       // }
    }

    
    //bullet collision function
    //===========================================================================

    private void OnCollisionEnter(Collision other)
    {
        float pow = 0;

        //Debug.Log("collision detected with " + other.gameObject.name + ", Tag: " + other.gameObject.tag);
        
        if (other.gameObject.tag == "Bullet")
        {
            GameObject bul = other.gameObject;
            float mod = bul.GetComponent<BulletBehavior>().power;
            

            if (mod > defense)
            {
                pow = mod - (defense * 10);
                //Debug.Log("pow: " + pow);
                //Debug.Log("currentHealth: " + currentHealth);
                currentHealth -= pow;
                healthScript.SetHealth(currentHealth/100, MySelf);
                //Debug.Log("got shoosted");

            }


        }
    }
    //================================================================================
    //this is where the details of each individual command the AI can issue will be stored, for example:
    

    // Forward
    public IEnumerator __Ahead(float distance)
    {
        int numFrames = (int)(distance / (baseSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++)
        {
            transform.Translate(new Vector3(0f, 0f, baseSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(mapSize, 0, mapSize)), new Vector3(-mapSize, 0, -mapSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();
        }
    }

    // Back
    public IEnumerator __Back(float distance)
    {
        int numFrames = (int)(distance / (baseSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++)
        {
            transform.Translate(new Vector3(0f, 0f, -baseSpeed * Time.fixedDeltaTime), Space.Self);
            Vector3 clampedPosition = Vector3.Max(Vector3.Min(transform.position, new Vector3(mapSize, 0, mapSize)), new Vector3(-mapSize, 0, -mapSize));
            transform.position = clampedPosition;

            yield return new WaitForFixedUpdate();
        }
    }

    //Left
    public IEnumerator __TurnLeft(float angle)
    {
        int numFrames = (int)(angle / (rotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++)
        {
            transform.Rotate(0f, -rotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();
        }
    }

    //Right
    public IEnumerator __TurnRight(float angle)
    {
        int numFrames = (int)(angle / (rotationSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++)
        {
            transform.Rotate(0f, rotationSpeed * Time.fixedDeltaTime, 0f);

            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator __DoNothing(float duration)
    {
        int numFrames = (int)(duration / Time.fixedDeltaTime);
        for (int f = 0; f < numFrames; f++)
        agent.speed = 0.0f;
        {
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator __FireFront()
    {

        if (weaponDefault == true)
        {
            
            if (timer > fireRateDefault)
            {
                //Debug.Log("Shoot");
                if (shotFired == false)
                {
                    CameraShaker.Instance.ShakeOnce(0.5f, 4f, 0.2f, 0.2f);//For the camera shake (Magnitude, roughmess, fadein, fadeout)

                    //Instantiate(Projectile_Prefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
                    GameObject projectile;

                    projectile = Instantiate(Projectile_Prefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation) as GameObject;
                    projectile.transform.Rotate(Vector3.left * 90);

                    Rigidbody Projectile_RigidBody;
                    Projectile_RigidBody = projectile.GetComponent<Rigidbody>();

                    Projectile_RigidBody.AddForce(transform.forward * Projectile_Forward_Force);
                    Debug.DrawRay(BulletSpawnPoint.position, transform.forward, Color.blue, 2);

                    shotFired = true;
                    float shotPower = damage * 10;//this is the bullet damage, needs to be read by TakeDamage
                    timer = 0;
                    shotFired = false;

                    //weaponDefault = false;

                    Destroy(projectile, 3.0f);
                }
            }
        }
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FollowTarget(float duration)
    {
        if (navTarget != null)
        {
            agent.destination = navTarget.transform.position;
            agent.speed = baseSpeed;

            int numFrames = (int)(duration / Time.fixedDeltaTime);
            for (int f = 0; f < numFrames; f++)
            {
                yield return new WaitForFixedUpdate();
            }
            agent.speed = 0.0f;
        }
        else
        {
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator __LookAtTarget(float duration)//Works the same as Followtarget for now, trying to figure out how to only rotate it, harder than it looks, can't simple set the speed to 0 or something.
    {
        if (navTarget != null)
        {
            agent.destination = navTarget.transform.position;
            agent.speed = baseSpeed;

            int numFrames = (int)(duration / Time.fixedDeltaTime);
            for (int f = 0; f < numFrames; f++)
            {
                yield return new WaitForFixedUpdate();
            }
            agent.speed = 0.0f;
        }
        else
        {
            yield return new WaitForFixedUpdate();
        }
    }

    public IEnumerator __StopFollowTarget(float duration)
    {
        agent.destination = navTarget.transform.position;
        agent.speed = 0.0f;
        navTarget = null;

        yield return new WaitForFixedUpdate();
    }
//Max's recent enums etc.
//===========================================================================
    public float __GetStats()//return all stats of the chosen player
    {
        return healthScript.health;

    }
    public IEnumerator __TakeDamage( float dmg)
    {
        currentHealth -= dmg;
        healthScript.SetHealth(currentHealth, MySelf);

        
        yield return currentHealth;

    }

    public IEnumerator __SetStats(float[] mode, float HP)
    {
        defense = mode[0] * HP;
        speed = mode[1] * HP;
        damage = mode[2] * HP;
        //healthScript.SetHealth(HP);
        healthScript.StatBars(mode);
        yield return ai.RunAI();    // <<<<<<<this makes the code run from the start again.
        yield return new WaitForFixedUpdate();

    }

    public IEnumerator __ToHell(int sink)
    {
        int numFrames = (int)(sink / (baseSpeed * Time.fixedDeltaTime));
        for (int f = 0; f < numFrames; f++)
        {
            transform.Translate(new Vector3( baseSpeed * Time.fixedDeltaTime, 0f, 0f), Space.Self);
            

            yield return new WaitForFixedUpdate();
        }
        
    }
    //=========================================================================
}
