using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Clean up missed brains!
	void OnTriggerEnter(Collider collider)
	{

		if(collider.tag == "Brain") {

			Destroy(collider.gameObject);

		}

	}

}
