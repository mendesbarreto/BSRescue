using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameStatus : MonoBehaviour 
{
	[SerializeField]
	private float gameGoal = 15;

	[SerializeField]
	private bool isKeyboard;

	[SerializeField]
	private Canvas winScreen;

	private bool pressKeyToPlay;

	public float GameGoal 
	{
		get { return gameGoal; }
		set { gameGoal = value; }
	}

	public bool IsKeyboard 
	{
		get { return isKeyboard; }
		set { isKeyboard = value; }
	}

	public Canvas WinScreen 
	{
		get { return winScreen; }
		set { winScreen = value; }
	}

	public bool PressKeyToPlay 
	{
		get { return pressKeyToPlay; }
		set { pressKeyToPlay = value; }
	}


	private const string KEY_KEYBOARD = "space";
	private const float ZERO_TOUCH = 0;

	private float amountTouch;
	private bool gameStart;

	private PlayerController playerController;
	private Rigidbody2D playerRb;

	private void Awake ()
	{
		playerController = GetComponent<PlayerController> ();
		winScreen.enabled = false;
		playerRb = GetComponent<Rigidbody2D> ();
	}

	private void Update ()
	{
		amountTouch = Input.touches.Length;
		ChooseConsole ();
		SetStartGame ();
	}

	private void FixedUpdate ()
	{
		// First Check if Game Start
		CheckGameStart ();
	}

	// Choose keyboard or touch
	private void ChooseConsole () 
	{
		if (!isKeyboard) 
		{
			CheckTouch ();
		} 
		else 
		{
			pressKeyToPlay = Input.GetKey (KEY_KEYBOARD);
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

	private void CheckTouch () 
	{
		if (amountTouch > ZERO_TOUCH) {
			pressKeyToPlay = true;
		} 
		else 
		{
			pressKeyToPlay = false;
		}
	}

	// Set Start Game
	private void SetStartGame () 
	{
		if (pressKeyToPlay) {
			gameStart = true;
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
			winScreen.enabled = true;
			playerController.StopPlayer ();
		}
	}

}
