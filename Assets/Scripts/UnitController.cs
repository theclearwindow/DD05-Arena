using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private BaseAI ai = null;
   
    private float baseSpeed = 100.0f; // values may change, but these will be what all stats are based on
   
    public void SetAI(BaseAI _ai) {
        ai = _ai;
        ai.Ship = this;
    }
   
    //this is where the details of each individual command the AI can issue will be stored, for example:
//   public IEnumerator __TurnRight(float angle) {
//      int numFrames = (int)(angle / (RotationSpeed * Time.fixedDeltaTime));
//      for (int f = 0; f < numFrames; f++) {
//         transform.Rotate(0f, RotationSpeed * Time.fixedDeltaTime, 0f);
//
//         yield return new WaitForFixedUpdate();            
//      }
//   }
//
//   public IEnumerator __DoNothing() {
//      yield return new WaitForFixedUpdate();
//   }
//
//   public IEnumerator __FireFront(float power) {
//      GameObject newInstance = Instantiate(CannonBallPrefab, CannonFrontSpawnPoint.position, CannonFrontSpawnPoint.rotation);
//      yield return new WaitForFixedUpdate();
//   }
}
