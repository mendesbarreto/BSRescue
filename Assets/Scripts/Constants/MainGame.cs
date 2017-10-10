using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

	private string mainMenuScene = "MainMenu";
	private string selectLvlScene = "SelectLvl";

	public string MainMenuScene {
		get { return mainMenuScene; }
		set { mainMenuScene = value; }
	}

	public string SelectLvlScene {
		get { return selectLvlScene; }
		set { selectLvlScene = value; }
	}

	public static MainGame instance;

	private void Awake()
	{
		instance = this;
		DontDestroyOnLoad(transform.gameObject);
	}
}
