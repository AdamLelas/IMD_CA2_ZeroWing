using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	void Start(){

		//ignore collision between allies holder and everything
		Physics2D.IgnoreLayerCollision (8, 10, true);
		Physics2D.IgnoreLayerCollision (9, 10, true);

		//ignore collision between player and allies
		Physics2D.IgnoreLayerCollision (11, 12, true);
		Physics2D.IgnoreLayerCollision (11, 13, true);


		//ignore collision between allies
		Physics2D.IgnoreLayerCollision (12, 13, true);

		//ignore bot ally with top holder
		Physics2D.IgnoreLayerCollision (12, 8, true);

		//ignore top ally with bot holder
		Physics2D.IgnoreLayerCollision (9, 13, true);

		Physics2D.IgnoreLayerCollision (9, 0, true);
		Physics2D.IgnoreLayerCollision (8, 0, true);
	}

}
