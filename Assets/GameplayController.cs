using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {


	[SerializeField] private GameObject brainPrefab;

	// get the Game Over Menu panel
	[SerializeField] private GameObject endGameMenu;

	// spawn position
	private float minX, maxX, minY, maxY, zPos;

	private float brainSpawnDelay = 2f;
	private float lastBrainSpawnTime = 0;

	// Use this for initialization
	void Start ()
	{

		minX = 8.0f;
		maxX = 20.0f;

		minY = 8.0f;
		maxY = 14.0f;

		zPos = -7.3f;


		for (int i = 0; i < 2; i++) {

			SpawnBrain();

		}


	}
	
	// Update is called once per frame
	void Update () {

		SpawnBrain();

	}


	// The player has died
	public void PlayerDied ()
	{

		// Set Game Over to true to stop platform moving
		GameManager.instance.GameOver = true;

		// wait a few seconds, then display the Game Over UI screen
		StartCoroutine( DisplayGameOverScreen() );
	}

	// Display the Game Over Screen
	IEnumerator DisplayGameOverScreen ()
	{

		// wait some time
		yield return new WaitForSeconds (2.0f);

		// turn on the End Game Menu
		endGameMenu.SetActive (true);
	}


	// Reset vars and Load the Main Menu scene
	public void LoadMainMenu ()
	{

		GameManager.instance.PlayerActive = false;
		GameManager.instance.GameOver = false;
		GameManager.instance.GameStarted = false;

		SceneManager.LoadScene("Main Menu");

	}

	// Reset vars and Load the Main Menu scene
	public void RestartGame()
	{

		GameManager.instance.PlayerActive = false;
		GameManager.instance.GameOver = false;
		GameManager.instance.GameStarted = true;

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}



	public void SpawnBrain ()
	{

		if (Time.time > (lastBrainSpawnTime + brainSpawnDelay)) {

			Debug.Log ("Spawning Brain");

//			Transform brainParent = (GameObject.Find ("Platform First").transform.position.x < GameObject.Find ("Platform Second").transform.position.x) 
//				? GameObject.Find ("Platform Second").transform : GameObject.Find ("Platform First").transform;
//
//			GameObject brain = Instantiate (brainPrefab, brainParent) as GameObject;
//
//			// generate spawn location
//			Vector3 brainSpawnLoc = new Vector3 (Random.Range (minX, maxX), Random.Range (minY, maxY), zPos); 

			GameObject brain = Instantiate (brainPrefab) as GameObject;

			Transform brainParent = (GameObject.Find ("Platform First").transform.position.x < GameObject.Find ("Platform Second").transform.position.x) 
				? GameObject.Find ("Platform Second").transform : GameObject.Find ("Platform First").transform;

			// generate spawn location
			Vector3 brainSpawnLoc = new Vector3 (Random.Range (minX, maxX), Random.Range (minY, maxY), zPos); 

			// move brain
			brain.transform.position = brainSpawnLoc;

			// parent it
			brain.transform.parent = brainParent;

			// reset the timer
			lastBrainSpawnTime = Time.time;

		}


	}


}
