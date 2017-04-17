using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	private Text scoreValue;

	//[SerializeField] private GameObject mainMenu;
	//[SerializeField] private GameObject endGameMenu;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;

	private int playerScore = 0;

	public bool PlayerActive {
		get { return playerActive; }
		set { playerActive = value; }
	}

	public bool GameOver {
		get { return gameOver; }
		set { gameOver = value; }
	}

	public bool GameStarted {
		get { return gameStarted; }
		set { gameStarted = value; }
	}

	public int PlayerScore {
		get { return playerScore; }
		set { playerScore = value; }
	}



	void Awake ()
	{
		if (instance == null) {

			instance = this;

		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

	}

	void Start ()
	{
		
	
	}

	// Set their best score ever
	public void SetBestScore (int newBestScore)
	{
		PlayerPrefs.SetInt("BESTSCORE", newBestScore);
		PlayerPrefs.Save();
	}

	// Retrieve the best score ever
	public int GetBestScore ()
	{
		return PlayerPrefs.GetInt("BESTSCORE");
	}


	private void UpdateScore ()
	{
		// Wire up scorevalue only once the game has started
		if (!scoreValue) {
			scoreValue = GameObject.Find ("ScoreValue").GetComponent<Text> ();
		}


		// set the score
		scoreValue.text = this.PlayerScore.ToString();

	}


	public void ScorePoints (int points)
	{

		this.PlayerScore += points;
		UpdateScore();


	}


	public void UpdateFinalScore ()
	{

		Debug.Log("Current Score [" + this.PlayerScore + "] || Best Score [" + GetBestScore() + "]");

		// update last score
		Text lastScoreValue = GameObject.Find ("LastScoreValue").GetComponent<Text> ();
		lastScoreValue.text = this.PlayerScore.ToString();

		// update best score
		if (this.PlayerScore > GetBestScore() ) {
			Debug.Log("new high score detected:  [" + this.PlayerScore + "] is larger than getbestscore [" + GetBestScore() + "]");

			SetBestScore(this.PlayerScore);
		}

		// update last score
		Text bestScoreValue = GameObject.Find ("BestScoreValue").GetComponent<Text> ();
		bestScoreValue.text = GetBestScore().ToString();


	}


	// Reset some variables
	public void ResetGame ()
	{
		this.PlayerScore = 0;
	}


}
