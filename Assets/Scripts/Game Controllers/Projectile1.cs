﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour {


	public int speed;

	void Start () {
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}
	

}
