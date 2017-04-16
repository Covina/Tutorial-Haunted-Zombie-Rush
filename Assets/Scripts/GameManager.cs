using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

	//[SerializeField] private GameObject mainMenu;
	//[SerializeField] private GameObject endGameMenu;

	private bool playerActive = false;
	private bool gameOver = false;
	private bool gameStarted = false;


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


	void Awake ()
	{
		if (instance == null) {

			instance = this;

		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

	}


}
