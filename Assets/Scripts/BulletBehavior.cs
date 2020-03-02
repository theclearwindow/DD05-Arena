using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        Destroy(this.gameObject);
        //Debug.Log("Hit");
    }
}
