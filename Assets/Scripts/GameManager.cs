using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	[SerializeField] private GameObject mainMenu;
	[SerializeField] private GameObject endGameMenu;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;


	public bool PlayerActive {
		get { return playerActive; }
	}

	public bool GameOver {
		get { return gameOver; }
	}

	public bool GameStarted {
		get { return gameStarted; }
	}


	void Awake ()
	{
		if (instance == null) {

			instance = this;

		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		Assert.IsNotNull(mainMenu);


//		playerActive = false;
//		gameOver = false;
//		gameStarted = false;

	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}





	public void PlayerStartedGame ()
	{
		playerActive = true;

	}

	// The player has died
	public void PlayerDied ()
	{

		// Set Game Over to true
		gameOver = true;

		// wait a few seconds, then display the Game Over UI screen
		StartCoroutine( DisplayGameOverScreen() );
	}

	// Display the Game Over Screen
	IEnumerator DisplayGameOverScreen ()
	{

		// wait some time
		yield return new WaitForSeconds(2.0f);

		// turn on the End Game Menu
		endGameMenu.SetActive(true);

	}


	public void EnterGame ()
	{
		mainMenu.SetActive(false);
		gameStarted = true;


		// Entering the Game from Main Menu
		Debug.Log("playerActive = " + playerActive + " || gameStarted = " + gameStarted + " || gameOver = " + gameOver + " ||");

	}


	public void MainMenu ()
	{
//		endGameMenu.SetActive(false);
//		mainMenu.SetActive(true);
		gameStarted = false;
		gameOver = false;
		playerActive = false;

		// Reload the scene
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}

}
