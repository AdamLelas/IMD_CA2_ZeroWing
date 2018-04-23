using UnityEngine;

//This script will handle the bullet adding itself back to the pool
public class Bullet : MonoBehaviour
{
	public int speed = 10;			//How fast the bullet moves
	public float lifeTime = 1;		//How long the bullet lives in seconds
	public int power = 1;			//Power of the bullet


	void Start ()
	{
		//Send the bullet "forward"
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
	}

}