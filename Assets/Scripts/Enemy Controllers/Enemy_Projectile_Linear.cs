using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile_Linear : MonoBehaviour {

	public int speed;

	void Start () {
		GetComponent<Rigidbody2D>().velocity = -transform.up.normalized * speed;
	}



}
