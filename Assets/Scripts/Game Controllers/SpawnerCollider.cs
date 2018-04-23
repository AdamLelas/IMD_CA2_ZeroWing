using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCollider : MonoBehaviour {

	public GameObject spawnerObject;
	public int count;
	public float rate;

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag.Equals("SpawnerCollider")){
			Debug.Log ("Spawners collided");
			GameObject instance = Instantiate (spawnerObject, transform.position, transform.rotation);
			instance.GetComponent<SpawnEnemy> ().setRate (rate);
			instance.GetComponent<SpawnEnemy> ().setCount (count);
		}	

	}
}
