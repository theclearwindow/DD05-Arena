using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    NavMeshAgent DeeDee;
    void Start()
    {
        DeeDee = GetComponent<NavMeshAgent>();
        destination = DeeDee.destination;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            DeeDee.destination = destination;
        }
    }
}
