using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Animator animator;
	private Rigidbody rigidBody;
	private AudioSource audioSource;

	private float jumpForce = 75f;
	private bool isJumping = false;

	[SerializeField] AudioClip sfxJump;
	[SerializeField] AudioClip sfxDeath;


	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
			if (Input.GetMouseButtonDown (0)) {

				GameManager.instance.PlayerStartedGame();

				//Debug.Log("Play Jump ANimation");
				animator.Play ("Jump");
				rigidBody.useGravity = true;
				isJumping = true;


			}
		}

	}


	void FixedUpdate ()
	{
		if (isJumping) {

			isJumping = false;
			rigidBody.velocity = new Vector2(0,0);

			rigidBody.AddForce(new Vector2 (0, jumpForce), ForceMode.Impulse );

			// play jump sound
			audioSource.PlayOneShot(sfxJump);

		}


	}

	// PLayer dies when it collides with the obstacle.
	void OnCollisionEnter (Collision collision)
	{
		Debug.Log("Player collided with " + collision.gameObject.name);
		
		if (collision.gameObject.tag == "Obstacle") {

			// bounce player
			rigidBody.AddForce (new Vector2(-50, 20), ForceMode.Impulse);

			// kill Player
			//Destroy(gameObject);
			audioSource.PlayOneShot(sfxDeath);

			GameManager.instance.PlayerDied();

		}


	}



}
