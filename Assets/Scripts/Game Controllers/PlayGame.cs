using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {
	public GameObject menu;

	public void Pause(){
		menu.SetActive (true);
	}

	public void Play()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}



}
