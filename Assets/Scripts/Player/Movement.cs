using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float GameGoal {
		get { return gameGoal; }
		set { gameGoal = value; }
	}

	[SerializeField]
	private float gameGoal;

	public float SpeedUp {
		get { return speedUp; }
		set { speedUp = value; }
	}

	[SerializeField]
	private float speedUp;

	public float SpeedDown {
		get { return speedDown; }
		set { speedDown = value; }
	}

	[SerializeField]
	private float speedDown;

	public float SpeedHorizontal {
		get { return speedHorizontal; }
		set { speedHorizontal = value; }
	}

	[SerializeField]
	private float speedHorizontal;

	public bool Keyboard {
		get { return keyboard; }
		set { keyboard = value; }
	}

	[SerializeField]
	private bool keyboard;

	public Canvas WinScreen {
		get { return winScreen; }
		set { winScreen = value; }
	}

	[SerializeField]
	private Canvas winScreen;

	private Rigidbody2D playerRb;
	private Death death;

	private float directionMove;
	private bool pressKey;
	private bool gameStart;

	// Use this for initialization
	private void Start () {
		winScreen.enabled = false;
		playerRb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	private void Update () {

		ChooseConsole ();

		CheckStartGame ();
	}
		
	private void FixedUpdate () {

		if (gameStart) {
			CheckGameGoal ();
		}

		if (Input.touches.Length > 0)
			pressKey = true;
		else
			pressKey = false;

	}

	// Choose keyboard or touch
	private void ChooseConsole () {
		if (!keyboard) {
			if (Input.touches.Length > 0) {
				pressKey = true;
			}
		} else {
			pressKey = Input.GetKey ("space");
		}
			
	}

	// Check Start Game
	private void CheckStartGame () {

		if (pressKey) {
			gameStart = true;
		}
	}

	// Check game goal
	private void CheckGameGoal () {
		
		if (playerRb.position.x < gameGoal) {
			Move ();
		} else {
			winScreen.enabled = true;
			StopPlayer ();

		}
	}

	// Select direction of the player (up or down)
	private void PlayerUpOrDown () {
		
		if (pressKey) {
			directionMove = 1;
		} else {
			directionMove = -1;
		}
	}

	// Player Move
	private void Move () {

		PlayerUpOrDown ();

		if(directionMove == 1)
			playerRb.velocity = new Vector2 (1 * speedHorizontal, directionMove * speedUp);
		else
			playerRb.velocity = new Vector2 (1 * speedHorizontal, directionMove * speedDown);

	}

	// Player Stop
	private void StopPlayer () {
		playerRb.velocity = new Vector2 (0, 0);
	}
}
