using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour {

	public GameObject NPC;
	public GameObject goalObject;
	public float WaitToSpawn;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnAgent", WaitToSpawn);
	}
	
	// Update is called once per frame
	void SpawnAgent () {
		GameObject na = (GameObject)Instantiate (NPC, this.transform.position, Quaternion.identity);
		na.GetComponent<WalkTo>().goal = goalObject.transform;
		Invoke ("SpawnAgent", Random.Range (5f, 6f));
	}
}
