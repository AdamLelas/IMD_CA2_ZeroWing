using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Projectile_Sphere: MonoBehaviour {
	int speed = 2;
	float diagonalSpeed = 1.5f;
	public bool stopped = false;

	void Start () {		
	}

	void FixedUpdate(){
//		if(efc.
			if (gameObject.tag.Equals ("NBul"))
				FireUp ();
			else if (gameObject.tag.Equals ("SBul"))
				FireDown ();
			else if (gameObject.tag.Equals ("EBul"))
				FireLeft ();
			else if (gameObject.tag.Equals ("WBul"))
				FireRight ();
			else if (gameObject.tag.Equals ("NWBul"))
				FireUpLeft ();
			else if (gameObject.tag.Equals ("SWBul"))
				FireDownLeft ();
			else if (gameObject.tag.Equals ("NEBul"))
				FireUpRight ();
			else if (gameObject.tag.Equals ("SEBul"))
				FireDownRight ();		
	}

	void FireUp(){
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}

	void FireDown(){
		GetComponent<Rigidbody2D>().velocity = -transform.up.normalized * speed;
	}

	void FireLeft(){
		GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
	}

	void FireRight(){
		GetComponent<Rigidbody2D>().velocity = -transform.right.normalized * speed;
	}

	void FireUpLeft(){

		float xMove, yMove;

		xMove = transform.right.x + transform.up.x;
		yMove = transform.up.y + transform.right.y;

		Vector3 move = new Vector3 (-xMove, yMove);

		GetComponent<Rigidbody2D>().velocity =
			move * diagonalSpeed;
	}

	void FireUpRight(){

		float xMove, yMove;

		xMove = transform.right.x + transform.up.x;
		yMove = transform.up.y + transform.right.y;

		Vector3 move = new Vector3 (xMove, yMove);

		GetComponent<Rigidbody2D>().velocity =
			move * diagonalSpeed;
	}

	void FireDownLeft(){

		float xMove, yMove;

		xMove = transform.right.x + transform.up.x;
		yMove = transform.up.y + transform.right.y;

		Vector3 move = new Vector3 (-xMove, -yMove);

		GetComponent<Rigidbody2D>().velocity =
			move * diagonalSpeed;
	}

	void FireDownRight(){

		float xMove, yMove;

		xMove = transform.right.x + transform.up.x;
		yMove = transform.up.y + transform.right.y;

		Vector3 move = new Vector3 (xMove, -yMove);

		GetComponent<Rigidbody2D>().velocity =
			move * diagonalSpeed;
	}




}
