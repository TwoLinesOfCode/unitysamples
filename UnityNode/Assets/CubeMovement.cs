using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeMovement : MonoBehaviour {

	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	public void MoveTo(Vector3 destination) {
		agent.SetDestination(destination);
	}
}
