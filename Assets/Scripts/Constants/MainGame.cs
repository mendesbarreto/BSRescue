using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

	private string mainMenuScene = "MainMenu";
	private string selectLvlScene = "SelectLvl";
	private string lvlScene = "Lvl";

	private string floorTag = "Floor";
	private string playerTag = "Player";

	public string MainMenuScene {
		get { return mainMenuScene; }
		set { mainMenuScene = value; }
	}

	public string SelectLvlScene {
		get { return selectLvlScene; }
		set { selectLvlScene = value; }
	}

	public string LvlScene {
		get { return lvlScene; }
		set { lvlScene = value; }
	}

	public string FloorTag {
		get { return floorTag; }
		set { floorTag = value; }
	}

	public string PlayerTag {
		get { return playerTag; }
		set { playerTag = value; }
	}

	public static MainGame instance;

	private void Awake () {
		instance = this;
		DontDestroyOnLoad(transform.gameObject);
	}
}
