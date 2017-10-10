using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LimitPlayerOnScreen ();
	}

	// Limit player on screen
	private void LimitPlayerOnScreen () {

		var distanceZ = (transform.position - Camera.main.transform.position).z;
		var topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceZ)).y;
		var bottonBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distanceZ)).y;

		//impedindo que o player suba
		transform.position = new Vector3 (transform.position.x,
			Mathf.Clamp (transform.position.y, topBorder, bottonBorder),
			transform.position.z);
	}
}
