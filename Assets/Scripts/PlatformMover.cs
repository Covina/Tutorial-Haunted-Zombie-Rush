using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

	[SerializeField] private float platformMovementSpeed = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// move the ground to the left
		transform.Translate(Vector3.right * (platformMovementSpeed * Time.deltaTime)); 




	}
}
