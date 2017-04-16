using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

	private float platformMovementSpeed = 3f;

	// Where on the left will it trigger
	private float resetPosition = -27.0f;

	// Where on the right does it move to.
	private float startPosition = 22.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{

		if (!GameManager.instance.GameOver) {

			// move the ground to the left
			transform.Translate (Vector3.left * (platformMovementSpeed * Time.deltaTime)); 

			// if its far to the left, move it to the end on the right.
			if (transform.position.x <= resetPosition) {

				// create new start location
				Vector3 newPos = new Vector3 (startPosition, transform.position.y, transform.position.z);

				// move it.
				transform.position = newPos;

			}

		} // game not over


	}
}
