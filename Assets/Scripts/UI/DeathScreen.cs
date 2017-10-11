using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour 
{
	public void MenuPress()
	{
		SceneManager.LoadScene(Constants.instance.MainMenuSceneName);
	}

	public void RestartPress()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
