using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDespawner : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other){
		if (!other.tag.Equals ("Enemy")) {
			Destroy (other.gameObject);
		}
	}


}
