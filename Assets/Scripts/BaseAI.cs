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



    //public StatControl Stats = new StatControl();

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

    public IEnumerator DoNothing(float duration)
    {
        yield return Unit.__DoNothing(duration);
    }

    public IEnumerator FireFront()
    {
        yield return Unit.__FireFront();
    }

    public IEnumerator TakeDamage(int power)
    {

        yield return Unit.__TakeDamage(power);
    }

    public virtual IEnumerator RunAI()
    {
        yield return null;
    }

    public virtual IEnumerator FollowTarget(float duration)
    {
        yield return Unit.__FollowTarget(duration);
    }
    
    public virtual IEnumerator LookAtTarget(float duration)
    {
        yield return Unit.__LookAtTarget(duration);
    }

    public virtual IEnumerator StopFollowTarget(float duration)
    {
        yield return Unit.__StopFollowTarget(duration);
    }
    //Max's recent enums etc.
    //====================================================================
    //there is no damage enum in BaseAI because I wasn't sure if it would be easier to change the individual AI health with a damage function on the script itself,
    //mostly because I don't yet understand how to use the returned values of the enums
    public virtual float GetStats()
    {
        return Unit.__GetStats();
    }
    
    public IEnumerator Damage(int damage, int life)
    {
        //=================================================================
        //where does this returned value go? it needs to go to currentHealth
        //=================================================================
        yield return TakeDamage(damage);
        
        

    }

    public IEnumerator SetStats(float[] mode, int hp)
    {
        return Unit.__SetStats(mode, hp);
    }
    
    //=============================================================
}

