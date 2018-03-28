using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomAudioScript : MonoBehaviour {

	public AudioClip[] clips;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) 
		{
			PlaySound ();
		}
	}

	void PlaySound ()
	{
		//Randomize
		int randomClip = Random.Range (0, clips.Length);

		//Create an AudioSource
		AudioSource source = gameObject.AddComponent<AudioSource> ();

		//Load clip into AudioSource
		source.clip = clips[randomClip];

		// Play the clip
		source.Play();

		Destroy (source, clips [randomClip].length);

	}
}
