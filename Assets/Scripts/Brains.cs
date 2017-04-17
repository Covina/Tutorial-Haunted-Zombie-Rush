using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brains : MonoBehaviour {

	private AudioSource audioSource;
	[SerializeField] private AudioClip sfxBrainChomp;


	private int brainPoints = 1;


	// Use this for initialization
	void Start ()
	{

		// Get the audio source component
		audioSource = GetComponent<AudioSource>();

		if (!audioSource) {
			Debug.Log("No audioSource found on this Brain");
		}

	}
	

	void OnTriggerEnter (Collider collider)
	{

		// did the player collide with it?
		if (collider.tag == "Player") {

			// Score Points
			GameManager.instance.ScorePoints (brainPoints);


			if (!sfxBrainChomp) {
				Debug.Log("No sfx found for sfxBrainChomp");
			}

			//Debug.Log("about to play sfx: [" + sfxBrainChomp + "]");

			// play jump sound
			//audioSource.PlayOneShot(sfxBrainChomp);
			AudioSource.PlayClipAtPoint(sfxBrainChomp, transform.position);

			// destroy brain collectable.
			Destroy(gameObject);


		}


	}
}
