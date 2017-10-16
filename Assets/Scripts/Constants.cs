using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour 
{
	private const string MAIN_MENU_SCENE_NAME = "MainMenu";
	private const string SELECT_LVL_SCENE_NAME = "SelectLvl";
	private const string LVL_SCENE_NAME = "Lvl";

	private const string FLOOR_TAG_NAME = "Floor";
	private const string PLAYER_TAG_NAME = "Player";

	private const string CAMERA_OBJ_NAME = "MainCamera";
	private const string PLAYER_OBJ_NAME = "Player";

	public string MainMenuSceneName 
	{
		get { return MAIN_MENU_SCENE_NAME; }
	}

	public string SelectLvlSceneName 
	{
		get { return SELECT_LVL_SCENE_NAME; }
	}

	public string LvlSceneName 
	{
		get { return LVL_SCENE_NAME; }
	}

	public string FloorTagName 
	{
		get { return FLOOR_TAG_NAME; }
	}

	public string PlayerTagName 
	{
		get { return PLAYER_TAG_NAME; }
	}

	public string CameraObjName 
	{
		get { return CAMERA_OBJ_NAME; }
	}

	public string PlayerObjName 
	{
		get { return PLAYER_OBJ_NAME; }
	}

	public static Constants instance;

	private void Awake() 
	{
		instance = this;
		DontDestroyOnLoad(transform.gameObject);
	}
}