/*
 * Unity Associate Game Developer - Unit 2
 *
 *   This script sets the goal for a NavMeshAgent, who
 *   (on each update) moves towards the Player's current
 *   location.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;		// configured in Inspector
    private NavMeshAgent navMeshAgent;	// target directed AI agent

    // Start is called before the first frame update
    void Start() {
	// get a reference to our NavMeshAgent
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    /*
     * Update is called once per frame
     *	  set the agent's movement goal to be where player is
     */
    void Update() {
        if (player == null) {
	    // if he has lost and hits escape, exit
	    if (Input.GetKey(KeyCode.Escape)) {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
	     	Application.Quit();
#endif
	    }
	} else
	    navMeshAgent.SetDestination(player.position);
    }
}
