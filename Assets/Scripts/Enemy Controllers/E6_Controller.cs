using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6_Controller : MonoBehaviour {

	public Transform shotSpawn;
	public GameObject enemyBullet;
	public float fireRate;
	float nextFire;

	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			FireEnemyBullet ();
		}
	}


	void FireEnemyBullet()
	{
		GameObject playerShip = GameObject.Find("Player");
		if (playerShip != null)
		{
			GameObject bullet = Instantiate(enemyBullet, shotSpawn.position, shotSpawn.rotation);
			bullet.transform.position = transform.position;
			Vector2 direction = playerShip.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyBullet>().SetDirection(direction);
		}
	}



}
