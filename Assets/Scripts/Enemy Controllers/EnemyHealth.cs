using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public GameObject Explosion;
	public GameObject drop;
	public GameObject scoreObj;
	ScoreAndLives scoreAndLives;

	public int startingHealth;
	public int currentHealth;
	public int pointsValue;


	public void TakeDamage(int amount){

//	play audio

		currentHealth -= amount;

		if (currentHealth <= 0) {
			scoreAndLives.incrementScore (pointsValue);
			Death ();
		}

	}

	void Death(){
		Destroy (gameObject);
		PlayExplosion ();
		if (drop != null) {
			Instantiate (drop, transform.position, transform.rotation);
		}
	}

	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate(Explosion);
		explosion.transform.position = transform.position;
	}

	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
		scoreObj = GameObject.FindGameObjectWithTag ("Score&Lives");
		scoreAndLives = scoreObj.GetComponent<ScoreAndLives> ();
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("PlayerBullet")) {
			TakeDamage (1);
			Destroy (other.gameObject);
		} else if (other.tag.Equals ("Player")) {
			TakeDamage (100);
		} else if (other.tag.Equals ("Ally")) {
			TakeDamage (1);
		}
//		else if(){
//			//collision with grabbed
//		}
			
	}
	public int getCurHealth()
	{
		return currentHealth;
	}


}
