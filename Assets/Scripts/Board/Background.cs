using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	[SerializeField]
	private GameObject Camera;
	[SerializeField]
	private float speedCenario;
	[SerializeField]
	private float moveInX;
	[SerializeField]
	private float moveInY;

	private void Update () {
		MoveBG();
	}

	private void MoveBG () {

		transform.position = new Vector2(moveInX + (Camera.transform.position.x / speedCenario), moveInY + (Camera.transform.position.y / speedCenario));
	}
}
