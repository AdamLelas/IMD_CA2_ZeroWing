using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals ("EnemyBulletTag")) {
			Destroy (other.gameObject);
		}else if (other.tag.Equals("PlayerBullet")){
			Destroy (other.gameObject);
		}
	}
}
