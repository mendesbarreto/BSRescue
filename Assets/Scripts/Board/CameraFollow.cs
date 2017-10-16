using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraFollow : MonoBehaviour 
{
	[SerializeField]
	private float maxX;
	[SerializeField]
	private float minX;

	private GameObject objPlayer;

	private float CAMERA_POSITION_Y = 0;
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
		objPlayer = GameObject.FindWithTag(Constants.instance.PlayerObjName);
	}

	// move camera
	private void MoveCamera()
	{
		transform.position = new Vector3(LimitMoveXWithPlayer(),
			CAMERA_POSITION_Y,
			currentCameraPositionZ);
	}

	// limiting move in x with the move of player
	private float LimitMoveXWithPlayer() 
	{
		float playerXPosition = objPlayer.transform.position.x;
		float moveIn = Mathf.Clamp(playerXPosition, minX, maxX);

		return moveIn;
	}
}
