using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{
    GameObject player;
    GameObject[] waypoints;
    int currentWP;
    public UnityEngine.AI.NavMeshAgent agent;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject; // grabs hold of transform
        currentWP = 0;

        agent = player.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return;
        if(Vector3.Distance(waypoints[currentWP].transform.position, player.transform.position) < 3.0f)
        {
            currentWP++;
            if(currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
        Debug.Log(currentWP);
        agent.SetDestination(waypoints[currentWP].transform.position);
    }   
}
