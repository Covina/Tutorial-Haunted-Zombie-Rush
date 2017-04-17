using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brains : MonoBehaviour {

	private AudioSource audioSource;

	private int brainPoints = 1;


	[SerializeField] private AudioClip sfxBrainChomp;

	// Use this for initialization
	void Start ()
	{
		audioSource = gameObject.GetComponent<AudioSource> ();

		if (!audioSource) {
			Debug.Log("No audioSource found on this Brain");
		}

	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}


	void OnTriggerEnter (Collider collider)
	{

		// did the player collide with it?
		if (collider.tag == "Player") {

			// Score Points
			GameManager.instance.ScorePoints(brainPoints);

			// Play the Sound Effect
			audioSource.clip = sfxBrainChomp;
			audioSource.Play();

			// destroy brain collectable.
			Destroy(gameObject);


			//Debug.Log("Current Score: " + GameManager.instance.PlayerScore);

		}


	}
}
