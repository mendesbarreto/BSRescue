using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BackgroundPositionChanger : MonoBehaviour 
{
    private const float SPEED = -2.5f;
	private const float POSITION_Y = 0;

	private void Update()
	{
		Move();
	}

	// move background
	private void Move()
	{
        transform.position = new Vector2(VelocityInHorizontal (),
			POSITION_Y);
	}

	// Set velocity x on background
	private float VelocityInHorizontal() 
	{
		float PositionXCamera = Camera.main.gameObject.transform.position.x;
        float velocityInHorizontal = PositionXCamera / SPEED;

		return velocityInHorizontal;
	}
}
