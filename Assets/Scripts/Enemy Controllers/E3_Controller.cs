using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_Controller : MonoBehaviour {

	public int speed = 10;
	public Enemy_Fire_Controller e;

	Rigidbody2D rb;


	void Start () {
		rb = GetComponent<Rigidbody2D>();
		e = GetComponent<Enemy_Fire_Controller> ();
	}

	void Update () {
		MoveShip ();
	}


	void MoveShip(){
		rb.velocity = transform.up.normalized * speed;
		if (transform.position.y < 0 ) {
			rb.velocity = transform.up.normalized * speed;
		} else if (transform.position.y >=0) {
			rb.velocity = new Vector2(0,0);
			e.canFire = true;
		}
	}



}
