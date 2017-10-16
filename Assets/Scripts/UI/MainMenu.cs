using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public void PlayPress() 
	{
		SceneManager.LoadScene(Constants.instance.SelectLvlSceneName);
	}

	public void QuitPress() 
	{
		Application.Quit();
	}
}
