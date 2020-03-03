using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public GameObject BulletPrefab = null;
    public Transform BulletSpawnPoint = null;
    private BaseAI ai = null;
    

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
        if (_AItype == AItype.Jorn)
        {
            SetAI(new CopyPasteAI());
            StartBattle();
        }
        if (_AItype == AItype.Omar)
        {
            SetAI(new MaxAI());
            StartBattle();
        }
        if (_AItype == AItype.Michael)
        {
            SetAI(new MaxAI());
            StartBattle();
        }
        if (_AItype == AItype.Sofie)
        {
            SetAI(new MaxAI());
            StartBattle();
        }
        if (_AItype == AItype.Theo)
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

    public float __GetHealth()
    {
        return 1.0f;
    }
}
