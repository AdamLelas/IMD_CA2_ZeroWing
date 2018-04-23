using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public int count;
	public GameObject spawn;
	public float spawnRate;
	public float nextSpawn;

	void Spawn(){
		if (count > 0 && Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			Instantiate (spawn, transform.position, transform.rotation);
			count--;
		}
		if (count <= 0) {
			Destroy (gameObject);
		}
	}

	void Update(){
		Spawn ();
	}


	public void setCount(int cnt){
		count = cnt;
	}

	public void setRate(float rate){
		spawnRate = rate;
	}

}
