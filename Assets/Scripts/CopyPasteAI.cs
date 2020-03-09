using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CopyPasteAI : BaseAI
{
    public override IEnumerator RunAI()
    {
        Debug.Log("CopyPasteAI RunAI started");
        while (true)
        {
            if (GetHealth() < 0.5f)
            {
                //yield return FireFront(1);
            }
            else
            {
                yield return Ahead(3);
                yield return FireFront(1);
                yield return TurnLeft(360);
                yield return Back(4);
                yield return TurnRight(90);
            }
            if (GetHealth() <= 0.0f)
            {
                break;
            }
        }
    }

    public override void OnScannedRobot(ScannedRobotEvent e)
    {
        Debug.Log("Enemy detected: " + e.Name + " at distance: " + e.Distance);
    }
}
