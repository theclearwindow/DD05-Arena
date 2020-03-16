using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class ScannedRobotEvent
//{
//   public string Name;
//    public float Distance;
//}

public class BaseAI : MonoBehaviour
{
    public UnitController Unit = null;
    public StatControl Stats = new StatControl();

    //public virtual void OnScannedRobot(ScannedRobotEvent e)
    //{
    // 
    //}

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

    public IEnumerator TakeDamage(int power, int currentHealth)
    {

        yield return Unit.__TakeDamage(power, currentHealth);
    }

    public virtual IEnumerator RunAI()
    {
        yield return null;
    }

    public virtual IEnumerator FollowTarget(float duration)
    {
        yield return Unit.__FollowTarget(duration);
    }
//Max's recent enums etc.
//====================================================================
//there is no damage enum in BaseAI because I wasn't sure if it would be easier to change the individual AI health with a damage function on the script itself,
//mostly because I don't yet understand how to use the returned values of the enums
    public virtual float GetStats()
    {
        return Unit.__GetStats();
    }

    public virtual float SetStats(float[] mode, int HP)
    {
        return Unit.__SetStats(mode, HP);
    }
    
    //=============================================================
}

