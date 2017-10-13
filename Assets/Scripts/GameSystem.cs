using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour 
{
	[SerializeField]
	private float gameGoal = 15;

	[SerializeField]
	private bool keyboard;

	public float GameGoal 
	{
		get { return gameGoal; }
		set { gameGoal = value; }
	}

	public bool Keyboard 
	{
		get { return keyboard; }
		set { keyboard = value; }
	}

	public static GameSystem instance;

	private void Awake () 
	{
		instance = this;
		DontDestroyOnLoad(transform.gameObject);
	}
}
