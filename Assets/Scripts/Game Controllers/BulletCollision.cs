using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

	EnemyHealth enemyHealth;

	void OnTriggerEnter2D(Collider2D other){
		enemyHealth.TakeDamage (1);
	}

}
