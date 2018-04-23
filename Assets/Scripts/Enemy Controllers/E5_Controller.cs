using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_Controller : MonoBehaviour {

	public float speed = 3.5f;


	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = -transform.right.normalized * speed;
	}

}
