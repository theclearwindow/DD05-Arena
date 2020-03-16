using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public GameObject BulletPrefab = null;
    public Transform BulletSpawnPoint = null;
    public HealthScript healthScript;
    public StatControl Stats;
    private BaseAI ai = null;

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
            SetAI(new MaxAI());
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
    }

    public void SetAI(BaseAI _ai)
    {
        ai = _ai;
        ai.Unit = this;
    }

    public void StartBattle()
    {
        StartCoroutine(ai.RunAI());
    }

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

    public IEnumerator __DoNothing()
    {
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FireFront(float power)
    {
        GameObject newInstance = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        yield return new WaitForFixedUpdate();
    }

    public IEnumerator __FollowTarget(float duration)
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

    public IEnumerator __StopFollowTarget(float duration)
    {
        agent.destination = navTarget.transform.position;
        agent.speed = 0.0f;

        yield return new WaitForFixedUpdate();
    }
//Max's recent enums etc.
//===========================================================================
    public float __GetStats()//return all stats of the chosen player
    {
        return healthScript.health;

    }
    public int __TakeDamage( int dmg,int currentHealth)
    {
        int answer = currentHealth - dmg;
        
        return answer;

    }

    public float __SetStats(float[] mode, int HP)
    {
        Stats.SetHealth(HP);
        Stats.SetNewMode(mode);
        return Stats.R;//returns health value

    }
    //=========================================================================
}
