using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour {

	private int direction = 1;
	private float startingY;
	private float movementDistance = 0.25f;

	private float movementSpeedDivisor = 10;

	// Use this for initialization
	void Start () {

		// get the starting y position
		startingY = transform.position.y;

		// randomize the movement speed;  higher is slower
		movementSpeedDivisor = Random.Range(8f, 16f);
	}
	
	// Update is called once per frame
	void Update ()
	{

		// get y
		float currentPosY = transform.position.y;
		Vector3 movement;

		if (currentPosY >= (startingY + movementDistance)) direction = -1;
		if (currentPosY <= (startingY - movementDistance)) direction = 1;

		transform.Translate(new Vector3(0,direction * (Time.deltaTime/movementSpeedDivisor),0) );

	}
}
