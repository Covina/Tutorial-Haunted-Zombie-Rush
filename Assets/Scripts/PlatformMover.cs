using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

	[SerializeField] private float platformMovementSpeed = 3f;

	// Where on the left will it trigger
	private float resetTriggerPositionX = -22.0f;

	// Where on the right does it move to.
	private float resetLocationPositionX = 27.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		// move the ground to the left
		transform.Translate (Vector3.right * (platformMovementSpeed * Time.deltaTime)); 

		// if its far to the left, move it to the end on the right.
		if (transform.position.x <= resetTriggerPositionX) {

			// create new start location
			Vector3 newPos = new Vector3(resetLocationPositionX, transform.position.y, transform.position.z);

			// move it.
			transform.position = newPos;

		}


	}
}
