using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcDamage : MonoBehaviour {

	public float damage = 10f;

	void OnTriggerEnter (Collider other)
	{	
		if (other.CompareTag ("Player")) 
		{
			other.gameObject.GetComponent<HealthScript>().TakeDamage (damage);
		}

	}


}
