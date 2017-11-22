using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PlayerGameStatus : MonoBehaviour 
{
	[SerializeField]
	private float gameGoal;

    [SerializeField]
    private int currentLevelNumber;

    private bool gameStart;
    private bool winGameStatus;

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

    private const int MAX_LEVEL_NUMBER = 10;

	private PlayerController playerController;
	private Rigidbody2D playerRb;
	private InputController inputController;
    private int nextLevel;

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
        winGameStatus = false;
        nextLevel = currentLevelNumber + 1;

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
		playerController.StopPlayer();
        UnlockNextLevel();

        //SceneManager.LoadScene(Constants.SceneName.COMIC);
	}

    private void UnlockNextLevel()
    {
        if (LevelControlers.instance.Levels[nextLevel] == 0 && currentLevelNumber < MAX_LEVEL_NUMBER)
        {
            LevelControlers.instance.Levels[nextLevel] = 1;
            SaveUnlockNextLevel();
        }
    }

    private void SaveUnlockNextLevel()
    {
        PlayerPrefs.SetInt(LevelControlers.instance.LevelsKey + (nextLevel), LevelControlers.instance.Levels[nextLevel]);
    }
}
