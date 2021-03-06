﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {


	private float platformMovementSpeed = 3f;

	// Where on the left will it trigger
	public float resetPosition = -27.0f;

	// Where on the right does it move to.
	public float startPosition = 22.0f;


	// Use this for initialization
	void Start ()
	{


	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{

		// move the platforms so long as the game is not over;
		if (!GameManager.instance.GameOver) {

			// move the object to the left
			transform.Translate (Vector3.left * (platformMovementSpeed * Time.deltaTime)); 


			// if its far to the left, move it to the end on the right.
			if (transform.position.x <= resetPosition) {

				// if its a lava rock, randomize its start position a little
				if (gameObject.tag == "Obstacle") {
					
					startPosition += Random.Range(-2f,2f);

				}

				// create new start location
				Vector3 newPos = new Vector3 (startPosition, transform.position.y, transform.position.z);

				// move it.
				transform.position = newPos;

			}


		} // game not over


	}
}
