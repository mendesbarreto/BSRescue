using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraFollow : MonoBehaviour 
{
    private float MAX_X = 100f;
    private float MIN_X = 0f;
	private float CAMERA_POSITION_Y = 0;

    private GameObject objPlayer;

	private float currentCameraPositionZ;

	private void Start()
	{
		LoadResorces();
	}

	private void Update()
	{
		MoveCamera();  
	}

	private void LoadResorces() 
	{
		currentCameraPositionZ = transform.position.z;
        objPlayer = GameObject.FindWithTag(Constants.ObjectName.PLAYER);
	}

	// move camera
	private void MoveCamera()
	{
        transform.position = new Vector3(LimitHorizontalMoveWithPlayer(),
			CAMERA_POSITION_Y,
			currentCameraPositionZ);
	}

	// limiting move in x with the move of player
	private float LimitHorizontalMoveWithPlayer() 
	{
		float playerHorizontalPosition = objPlayer.transform.position.x;
        float moveIn = Mathf.Clamp(playerHorizontalPosition, MIN_X, MAX_X);

		return moveIn;
	}
}
