using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class MainMenu : MonoBehaviour 
{
	public void PlayPress() 
	{
        SceneManager.LoadScene(Constants.SceneName.SELECT_LVL);
	}

	public void QuitPress() 
	{
		Application.Quit();
	}
}
