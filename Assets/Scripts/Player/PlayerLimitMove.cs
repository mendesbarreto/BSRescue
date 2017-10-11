using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimitMove : MonoBehaviour 
{	
	private const float REFERENCE_X_POSITION = 0;
	private const float REFERENCE_Z_POSITION = 0;
	private const string MIN_LIMIT = "min";
	private const string MAX_LIMIT = "max";

	private float referenceYPosition;
	private float currentPlayerPositionX;
	private float currentPlayerPositionY;
	private float currentPlayerPositionZ;

	private void Update () 
	{
		CurrentPositions ();

		PlayerLimitOnScreen ();
	}

	// Get current points position (x, y, z) of player
	private void CurrentPositions () 
	{
		currentPlayerPositionX = transform.position.x;
		currentPlayerPositionY = transform.position.y;
		currentPlayerPositionX = transform.position.z;
	}

	// Limit player on screen
	private void PlayerLimitOnScreen () 
	{
		float limitY = Mathf.Clamp (currentPlayerPositionY, 
									LimitYOnScreen (MIN_LIMIT), 
									LimitYOnScreen (MAX_LIMIT));

		Vector3 limitVector = new Vector3 (currentPlayerPositionX,
										   limitY,
										   currentPlayerPositionX);

		transform.position = limitVector;
	}

	// Limit Y position to screen
	private float LimitYOnScreen (string typeOfLimit) 
	{
		SelectReferenceYPosition (typeOfLimit);

		Vector3 referencePoints = new Vector3 (REFERENCE_X_POSITION, 
											   referenceYPosition, 
											   REFERENCE_Z_POSITION);

		float limitY = Camera.main.ViewportToWorldPoint (referencePoints).y;

		return limitY;
	}

	// Select Reference Y position
	private float SelectReferenceYPosition (string typeOfLimit) 
	{
		if (typeOfLimit == MIN_LIMIT) {
			referenceYPosition = 0;
		} else {
			referenceYPosition = 1;
		}

		return referenceYPosition;
	}
}
