using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannedRobotEvent
{
    public string Name;
    public float Distance;
}

public class BaseAI : MonoBehaviour
{
    public UnitController Unit = null;
    public StatControl Stats = new StatControl();

    public virtual void OnScannedRobot(ScannedRobotEvent e)
    {
        // 
    }

    // actions the AI can call on and the values to apply to those actions:
    public IEnumerator Ahead(float distance)
    {
        yield return Unit.__Ahead(distance);
    }

    public IEnumerator Back(float distance)
    {
        yield return Unit.__Back(distance);
    }

    public IEnumerator TurnLeft(float angle)
    {
        yield return Unit.__TurnLeft(angle);
    }

    public IEnumerator TurnRight(float angle)
    {
        yield return Unit.__TurnRight(angle);
    }

    public IEnumerator FireFront(float power)
    {
        yield return Unit.__FireFront(power);
    }

    public virtual IEnumerator RunAI()
    {
        yield return null;
    }

    public virtual float GetHealth()
    {
        return Unit.__GetHealth();
    }
}

