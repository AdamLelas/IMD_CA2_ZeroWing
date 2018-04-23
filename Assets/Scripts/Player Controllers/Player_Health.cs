using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

	public int startingHealth = 1;
	public bool hasDied;
	public int health;

	void Start () {
		hasDied = false;
	}


}
