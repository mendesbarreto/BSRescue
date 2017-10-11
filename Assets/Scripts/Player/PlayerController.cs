using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	private float gameGoal;

	[SerializeField]
	private float speedUp;

	[SerializeField]
	private float speedDown;

	[SerializeField]
	private float speedHorizontal;

	[SerializeField]
	private bool keyboard;

	[SerializeField]
	private Canvas winScreen;

	public float GameGoal 
	{
		get { return gameGoal; }
		set { gameGoal = value; }
	}

	public float SpeedUp 
	{
		get { return speedUp; }
		set { speedUp = value; }
	}

	public float SpeedDown 
	{
		get { return speedDown; }
		set { speedDown = value; }
	}

	public float SpeedHorizontal 
	{
		get { return speedHorizontal; }
		set { speedHorizontal = value; }
	}

	public bool Keyboard 
	{
		get { return keyboard; }
		set { keyboard = value; }
	}

	public Canvas WinScreen 
	{
		get { return winScreen; }
		set { winScreen = value; }
	}

	private const float ZERO_TOUCH = 0;
	private const string PLAY_KEY_KEYBOARD = "space";
	private const float DIRECTION_UP = 1;
	private const float DIRECTION_DOWN = -1;
	private const float DIRECTION_MOVE_HORIZONTAL = 1;

	private Rigidbody2D playerRb;
	private Death death;

	private float directionMoveVertical;
	private bool pressKeyToPlay;
	private bool gameStart;
	private float amountTouch;

	private void Start () 
	{
		LoadResources ();
	}

	private void Update () 
	{
		amountTouch = Input.touches.Length;

		ChooseConsole ();

		SetStartGame ();
	}

	private void FixedUpdate () 
	{
		CheckGameStart ();

		CheckTouch ();
	}

	private void LoadResources () 
	{
		winScreen.enabled = false;
		playerRb = GetComponent<Rigidbody2D> ();
	}

	// Choose keyboard or touch
	private void ChooseConsole () 
	{
		if (!keyboard) 
		{
			CheckTouch ();
		} 
		else 
		{
			pressKeyToPlay = Input.GetKey (PLAY_KEY_KEYBOARD);
		}
	}

	// check if player is touching
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
			Move ();
		} 
		else 
		{
			winScreen.enabled = true;
			StopPlayer ();
		}
	}

	// Select direction of the player (up or down)
	private void PlayerUpOrDown () 
	{
		if (pressKeyToPlay) 
		{
			directionMoveVertical = DIRECTION_UP;
		} 
		else 
		{
			directionMoveVertical = DIRECTION_DOWN;
		}
	}

	// Player Move
	private void Move () 
	{
		float moveToHorizontal = DIRECTION_MOVE_HORIZONTAL * speedHorizontal;

		PlayerUpOrDown ();

		if (directionMoveVertical == DIRECTION_UP) 
		{
			playerRb.velocity = new Vector2 (moveToHorizontal, directionMoveVertical * speedUp);
		} 
		else 
		{
			playerRb.velocity = new Vector2 (moveToHorizontal, directionMoveVertical * speedDown);
		}
	}

	// Player Stop
	private void StopPlayer () 
	{
		playerRb.velocity = Vector2.zero;
	}
}
