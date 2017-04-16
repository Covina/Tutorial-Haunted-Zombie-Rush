using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	// get the Game Over Menu panel
	[SerializeField] private GameObject endGameMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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


}
