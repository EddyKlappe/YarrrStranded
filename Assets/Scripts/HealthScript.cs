using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class HealthScript : MonoBehaviour {

	public float max_health = 100f;
	public float cur_health = 1f;
	public bool alive = true;

	public Text deathText;
	public Text healthText;

	public AudioClip[] deathSound;
	public AudioClip[] damageSound;

	public GameObject controller1;
	public GameObject gun;

	// Use this for initialization
	void Start () 
	{
		alive = true;
		cur_health = max_health;
		SetHealthText ();
		deathText.text = "";
	}
	
	public void TakeDamage (float amount)
	{
		if (!alive) 
		{
			return;
		}

		if (cur_health <= 0 && alive) 
		{
			
			PlayDeathSound ();
			cur_health = 0;
			alive = false;
			controller1.GetComponent<CharacterController>().enabled = false;
			gun.SetActive (false);
		}

		if (alive == false) 
		{
			deathText.text = "DEAD!";
		}
		SetHealthText ();
		cur_health -= amount;
		PlayDamageSound ();

	}



	void SetHealthText ()
	{
		healthText.text = "Health: " + cur_health.ToString ();
	}

	void PlayDeathSound ()
	{
		//Randomize
		int randomClip = Random.Range (0, deathSound.Length);

		//Create an AudioSource
		AudioSource source = gameObject.AddComponent<AudioSource> ();

		//Load clip into AudioSource
		source.clip = deathSound[randomClip];

		// Play the clip
		source.Play();

		Destroy (source, deathSound [randomClip].length);

	}

	void PlayDamageSound ()
	{
		//Randomize
		int randomClip = Random.Range (0, damageSound.Length);

		//Create an AudioSource
		AudioSource source = gameObject.AddComponent<AudioSource> ();

		//Load clip into AudioSource
		source.clip = damageSound[randomClip];

		// Play the clip
		source.Play();

		Destroy (source, damageSound [randomClip].length);

	}
}

