using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

	public Transform shotSpawn;
	public GameObject shot;
	public GameObject cam;
	public GameObject explosioGO;
	public GameObject redAllyOne;
	public GameObject redAllyTwo;
	public GameObject redAllyThree;
	public GameObject blueAllyOne;
	public GameObject blueAllyTwo;
	public GameObject blueAllyThree;
	public PlayGame pg;

	public ScoreAndLives livesObj;

	public AudioSource audio;

	GameObject instanceRA1;
	GameObject instanceBA1;

	public int powerlevel;

	public float fireRate;
	private float nextFire;

	public int playerSpeed = 10;
	public float moveX;
	private float moveY;

	public bool hasRedPowerup = false;
	public bool hasBluePowerup = false;

	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag ("MainCamera");
		rb = GetComponent<Rigidbody2D> ();
		livesObj = GameObject.FindGameObjectWithTag ("Score&Lives").GetComponent<ScoreAndLives>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (hasRedPowerup) {
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			} else if (hasBluePowerup) {				
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);			
			} else {
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
			audio.Play ();
		}
		PlayerMove();
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (5);
	}

	void PlayerMove(){
		//CONTROLS
		moveX = Input.GetAxis ("Horizontal");
		moveY = Input.GetAxis ("Vertical");

		//PHYSICS
		gameObject.GetComponent<Rigidbody2D> ().velocity 
		= new Vector2 (moveX * playerSpeed, moveY * playerSpeed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("Powerup-red")) {
			Destroy (other.gameObject);
			if (!hasRedPowerup) {
				hasRedPowerup = true;
				hasBluePowerup = false;
				DestroyBlues ();
				powerlevel = 1;
				instanceRA1 = Instantiate (redAllyOne, gameObject.transform);
			}
			else if (hasRedPowerup) {
				if (powerlevel == 1) {
					DestroyReds ();
					powerlevel++;
					instanceRA1 = Instantiate (redAllyTwo, gameObject.transform);
				} else if (powerlevel == 2) {
					DestroyReds ();
					powerlevel++;
					instanceRA1 = Instantiate (redAllyThree, gameObject.transform);
				} else if (powerlevel == 3) {
					//add 1000 points to score
				}
			}

		} else if( other.tag.Equals("Powerup-blue")){
			Destroy (other.gameObject);
			if (powerlevel == 0) {
				hasRedPowerup = true;
				hasBluePowerup = false;			
				DestroyBlues ();
				powerlevel = 1;
				instanceRA1 = Instantiate (redAllyOne, gameObject.transform);
			}else if (!hasBluePowerup) {
				hasRedPowerup = false;
				hasBluePowerup = true;
				powerlevel = 1;
				DestroyReds ();
				instanceBA1 = Instantiate (blueAllyOne, gameObject.transform);
			}
			else if (hasBluePowerup) {
				if (powerlevel == 1) {
					DestroyBlues ();
					powerlevel++;
					instanceBA1 = Instantiate (blueAllyTwo, gameObject.transform);
				} else if (powerlevel == 2) {
					DestroyBlues ();
					powerlevel++;
					instanceBA1 = Instantiate (blueAllyThree, gameObject.transform);
				} else if (powerlevel == 3) {
					//add points
				}
			}
		
		} else if(!other.tag.Equals("PlayerBullet")){
			Debug.Log ("Collision with player");
			PlayExplosion ();
			Death ();
		}
	}
		
	void DestroyBlues(){
		Debug.Log ("BlueDestroy");
		Destroy (instanceBA1);
	}

	void DestroyReds(){
		Debug.Log ("RedDestroy");
		Destroy (instanceRA1);
	}

	void Death(){
		Destroy (gameObject);
		livesObj.decrementLives ();
		cam.GetComponent<CameraSystem>().setCamSpeed (0f);
		cam.GetComponent<CameraSystem> ().modifyPositionX (1);
		pg.Pause ();
	}

	void PlayExplosion()
	{
		GameObject explosion = Instantiate(explosioGO);
		explosion.transform.position = transform.position;
	}






}
