using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerGameStatus : MonoBehaviour 
{
	[SerializeField]
	private float gameGoal = 15;

	[SerializeField]
	private Canvas winScreen;

    private bool gameStart;
    private bool winGameBool;

	public Canvas WinScreen 
	{
		get { return winScreen; }
		set { winScreen = value; }
	}

    public bool GameStart
    {
        get { return gameStart; }
        set { gameStart = value; }
    }

    public bool WinGameBool
    {
        get { return winGameBool; }
        set { winGameBool = value; }
    }

	private PlayerController playerController;
	private Rigidbody2D playerRb;
	private InputController inputController;

	private void Start()
	{
		LoadResources();
	}

	private void Update()
	{
		SetStartGame();
	}

	private void FixedUpdate()
	{
        SetCheckerGameGoal();
	}

	private void LoadResources()
	{
		winScreen.enabled = false;
        winGameBool = false;

		playerController = GetComponent<PlayerController>();
		inputController = GetComponent<InputController>();

		playerRb = GetComponent<Rigidbody2D>();
	}

	// Set Start Game
	private void SetStartGame() 
	{
		if(inputController.PressKeyToPlay)
		{
			gameStart = true;
		}
	}

	// check if game start
    private void SetCheckerGameGoal()
	{
		if(gameStart) 
		{
			CheckGameGoal();
		}
	}

	// Check game goal
	private void CheckGameGoal() 
	{
		if(playerRb.position.x < gameGoal) 
		{
			playerController.Move();
		} 
		else 
		{
			WinGame();
		}
	}

	private void WinGame()
	{
        winGameBool = true;
		winScreen.enabled = true;
		playerController.StopPlayer();
	}
}
