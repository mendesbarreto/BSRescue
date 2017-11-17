using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour 
{
    [SerializeField]
    private Animator propellerAnimator;

    [SerializeField]
    private AudioSource propellerAudio;

    public Animator PropellerAnimator
    {
        get { return propellerAnimator; }
        set { propellerAnimator = value; }
    }

    public AudioSource PropellerAudio
    {
        get { return propellerAudio; }
        set { propellerAudio = value; }
    }

	private const float DIRECTION_UP = 1;
	private const float DIRECTION_DOWN = -1;
	private const float DIRECTION_MOVE_HORIZONTAL = 1;
	private const float SPEED_UP_PLAYER = 2.5f;
	private const float SPEED_DOWN_PLAYER = 1.5f;
	private const float SPEED_HORIZONTAL_PLAYER = 3f;

	private InputController inputController;
	private Rigidbody2D playerRb;
    private Animator playerAnimator;

	private float moveToHorizontal;
	private float moveToVertical;

	private void Start() 
	{
		LoadResources();
	}

	private void LoadResources() 
	{
		playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
		inputController = GetComponent<InputController>();
	}

	// Select direction of the player (up or down)
	private void DirectionVertical() 
	{
		if(inputController.PressKeyToPlay) 
		{
            propellerAnimator.SetTrigger("IncreasesSpeed");
            propellerAudio.pitch = 2.5f;
            playerAnimator.ResetTrigger("DownPlayer");
            playerAnimator.SetTrigger("UpPlayer");
			moveToVertical = DIRECTION_UP * SPEED_UP_PLAYER;
		} 
		else 
		{
            propellerAnimator.SetTrigger("DecreasesSpeed");
            propellerAudio.pitch = 1f;
            playerAnimator.ResetTrigger("UpPlayer");
            playerAnimator.SetTrigger("DownPlayer");
			moveToVertical = DIRECTION_DOWN * SPEED_DOWN_PLAYER;
		}
	}

	// Player Move
	public void Move() 
	{
		moveToHorizontal = DIRECTION_MOVE_HORIZONTAL * SPEED_HORIZONTAL_PLAYER;

		DirectionVertical();

		playerRb.velocity = new Vector2(moveToHorizontal, moveToVertical);
	}

	// Player Stop
	public void StopPlayer() 
	{
        //playerRb.velocity = Vector2.zero;
        playerRb.velocity = new Vector2(0, DIRECTION_DOWN * SPEED_DOWN_PLAYER);
	}
}
