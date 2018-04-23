using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire_Controller : MonoBehaviour {

	public Transform shotSpawn;
	public GameObject shot;

	public float fireRate;
	private float nextFire;
	public bool canFire = false;

	void Update () {
		if (Time.time > nextFire && canFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	public void setFireRate(float fireRate)
	{
		this.fireRate = fireRate;
	}

}
