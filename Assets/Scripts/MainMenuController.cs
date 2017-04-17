using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	private Text bestScoreValue;

	// Called when clicking PLAY from Main Menu
	public void StartGame ()
	{
		// ensure cleanup
		GameManager.instance.ResetGame();

		SceneManager.LoadScene("Gameplay");
	}


	void Start ()
	{
		bestScoreValue = GameObject.Find("BestScoreValue").GetComponent<Text>();

		int tmp = GameManager.instance.GetBestScore();

		bestScoreValue.text = (tmp > 0) ? tmp.ToString() : "TBD";
		

	}


}
