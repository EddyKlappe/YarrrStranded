using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkTo : MonoBehaviour 
{
	public Transform goal;
	void Update ()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = goal.position;
	}

}
