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
		scoreValue = GameObject.Find("ScoreValue").GetComponent<Text>();
		UpdateScore ();
	}


	private void UpdateScore ()
	{
		// set the score
		scoreValue.text = this.PlayerScore.ToString();

	}


	public void ScorePoints (int points)
	{

		this.PlayerScore += points;
		UpdateScore();


	}


}
