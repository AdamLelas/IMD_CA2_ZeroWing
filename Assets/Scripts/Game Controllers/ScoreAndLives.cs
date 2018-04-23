using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreAndLives : MonoBehaviour {

    //public GameObject scoring;
    //public GameObject lives;

    public Text scorestxt;
    public Text livestxt;
	public int startingLives = 3;
    int score;
    int lives;

    // Use this for initialization
    void Start () {
		lives = startingLives;
        scorestxt.text = "";
        livestxt.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        scorestxt.text = "" + score;
        livestxt.text = "" + lives;
    }

	public void incrementScore(int scr){
		score += scr;
	}
	public void decrementLives(){
		lives--;	
		if (lives == 0) {
			
		}
	}
}
