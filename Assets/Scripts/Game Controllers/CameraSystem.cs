using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

	private GameObject player;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	public float cameraSpeed = 0.0005f;



	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}



	void LateUpdate () {
		var cameraPosition = Camera.main.gameObject.transform.position;
		cameraPosition.x += cameraSpeed;
		Camera.main.gameObject.transform.position = cameraPosition;
	}

	public void setCamSpeed(float cameraSpeed)
	{
		this.cameraSpeed = cameraSpeed;
	}

	public void modifyPositionX (float amt){
		Vector3 change = new Vector3 (amt, 0, 0);
		transform.position = transform.position - change;

	}
}
