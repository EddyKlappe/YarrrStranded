using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class Gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public float impactForce = 30f;
	float AbleTimeToFire = 0f;
	float NextTimeToFire = 1.25f;

	private int count;
	private int score = 100;
	public Text scoreText;

	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;

	public Animator anim;

	public AudioClip[] clips;
	public AudioMixerGroup output;


	void Start()
	{
		
		count = 0;
		SetscoreText ();
	}

	// Update is called once per frame
	void Update () {
		AbleTimeToFire -= Time.deltaTime;

		if (Input.GetButtonDown ("Fire1") && AbleTimeToFire <= 0) 
		{
			Shoot ();
			AbleTimeToFire = NextTimeToFire;
		}
	}

	void Shoot()
	{
		muzzleFlash.Play ();
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		anim.SetBool ("ShootAnim", true);
		StartCoroutine (GunAnimCooldown());

		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
		{
			//Debug.Log (hit.transform.name);



			Target target = hit.transform.GetComponent<Target>();

			if (target != null) 
			{
				target.TakeDamage (damage);

				if (target.tag == "enemy") 
				{
					count = count + score;
					if (count % 500 == 0) 
					{
						PlaySound ();
					}
					SetscoreText ();
				}
					
			}

			if (hit.rigidbody != null) 
			{
				hit.rigidbody.AddForce (-hit.normal * impactForce);
			}



			GameObject impactGO = Instantiate (impactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGO, 2f);



		}
	}

	IEnumerator GunAnimCooldown(){
		yield return new WaitForSeconds(0.1f);
		//hij wacht 0.1 sec
		anim.SetBool ("ShootAnim", false);
	}


	void SetscoreText ()
	{
		scoreText.text = "Score: " + count.ToString ();
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
