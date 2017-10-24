using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PlayerGameStatus : MonoBehaviour 
{
	[SerializeField]
	private float gameGoal;

	[SerializeField]
	private Canvas winScreen;

    private bool gameStart;
    private bool winGameStatus;

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

    public bool WinGameStatus
    {
        get { return winGameStatus; }
        set { winGameStatus = value; }
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
        winGameStatus = false;

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
        winGameStatus = true;
		//winScreen.enabled = true;
		playerController.StopPlayer();

        SceneManager.LoadScene(Constants.SceneName.COMIC);
	}
}
