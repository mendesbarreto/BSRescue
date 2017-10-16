using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameStatus : MonoBehaviour 
{
	[SerializeField]
	private float gameGoal = 15;

	[SerializeField]
	private Canvas winScreen;

	public Canvas WinScreen 
	{
		get { return winScreen; }
		set { winScreen = value; }
	}

	private bool gameStart;

	private PlayerController playerController;
	private Rigidbody2D playerRb;
	private InputController inputController;

	private void Start ()
	{
		LoadResources ();
	}

	private void Update ()
	{
		SetStartGame ();
	}

	private void FixedUpdate ()
	{
		CheckGameStart ();
	}

	private void LoadResources ()
	{
		winScreen.enabled = false;

		playerController = GetComponent<PlayerController> ();
		inputController = GetComponent<InputController> ();

		playerRb = GetComponent<Rigidbody2D> ();
	}

	// Set Start Game
	private void SetStartGame () 
	{
		if (inputController.PressKeyToPlay)
		{
			gameStart = true;
		}
	}

	// check if game start
	private void CheckGameStart ()
	{
		if (gameStart) 
		{
			CheckGameGoal ();
		}
	}

	// Check game goal
	private void CheckGameGoal () 
	{
		if (playerRb.position.x < gameGoal) 
		{
			playerController.Move ();
		} 
		else 
		{
			WinGame ();
		}
	}

	private void WinGame ()
	{
		winScreen.enabled = true;
		playerController.StopPlayer ();
	}
}
