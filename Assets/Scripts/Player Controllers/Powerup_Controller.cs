using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Controller : MonoBehaviour {

	public float fireRate;
	private float nextFire = 0.25f;

	//	max distance from player
	//	private float maxDistance = 5;

	public GameObject gunShot;
	public Transform shotSpawn;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public GameObject gun;

	void Update () {		
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(gunShot, shotSpawn.position, shotSpawn.rotation);
			Instantiate (gunShot, shotSpawn2.position,shotSpawn2.rotation);
			Instantiate (gunShot, shotSpawn3.position,shotSpawn3.rotation);
		}

	}


	void LateUpdate(){
		GoToPosition ();
	}

	//pushes powerup away from player
	void GoToPosition(){
//		if(gunShot.tag.Equals("TopGun")){
//			GetComponent<Rigidbody2D>().velocity = transform.up.normalized * 2;
//		}
//		else if(gunShot.tag.Equals("BotGun")){		
//			GetComponent<Rigidbody2D>().velocity = transform.up.normalized * 2;
//		}

		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * -6;			
	}

}
