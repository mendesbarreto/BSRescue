using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour 
{
	[SerializeField]
	private float speedCenario;

	private float BG_POSITION_Y = 0;

	private void Update()
	{
		MoveBG();
	}

	// move background
	private void MoveBG()
	{
		transform.position = new Vector2(VelocityBGInX (),
			BG_POSITION_Y);
	}

	// Set velocity x on background
	private float VelocityBGInX() 
	{
		float PositionXCamera = Camera.main.gameObject.transform.position.x;
		float velocityBG = PositionXCamera / speedCenario;

		return velocityBG;
	}
}
