using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Called when clicking PLAY from Main Menu
	public void StartGame ()
	{
		// ensure cleanup
		GameManager.instance.ResetGame();

		SceneManager.LoadScene("Gameplay");
	}

}
