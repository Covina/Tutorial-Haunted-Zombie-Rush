using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRock : PlatformMover {

	[SerializeField] private Vector3 topPos;
	[SerializeField] private Vector3 bottomPos;
	[SerializeField] private float rockMovementSpeed = 2f;
	private float rockRotationSpeed = 100f;

	// Use this for initialization
	void Start () {

		resetPosition = -17f;
		startPosition = 10f;

		StartCoroutine( Move(bottomPos) );
	}
	
	// Update is called once per frame
	protected override void Update ()
	{

		// only move the rocks if the player has clicked to start the game
		if (GameManager.instance.PlayerActive) {
			// rotate the lava rock
			//transform.Rotate(0, Time.deltaTime * rockRotationSpeed, 0);

			base.Update ();
		}												
	}


	// Up and Down vertical movement
	IEnumerator Move (Vector3 target)
	{


		// check diff on the Y
		while(Mathf.Abs( (target - transform.localPosition).y) > 0.20f) {

			// ternary operator
			Vector3 direction = (target.y == topPos.y) ? Vector3.up : Vector3.down;

			// move the object
			transform.localPosition += direction * Time.deltaTime * rockMovementSpeed;



			yield return null;

		}

		//Debug.Log("Reached end point now changing direction");

		// small delay
		yield return new WaitForSeconds (0.5f);

		// set new direction
		Vector3 newTarget = (target.y == topPos.y) ? bottomPos : topPos;

		// recursively call 
		StartCoroutine( Move(newTarget) );

	}




}
