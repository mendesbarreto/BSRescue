using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MenuPress()
	{
		SceneManager.LoadScene(MainGame.instance.MainMenuScene);
	}

	public void RestartPress()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
