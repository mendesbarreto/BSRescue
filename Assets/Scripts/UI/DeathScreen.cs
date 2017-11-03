using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class DeathScreen : MonoBehaviour 
{
	public void MenuPress()
	{
        SceneManager.LoadScene(Constants.SceneName.MAIN_MENU);
	}

	public void RestartPress()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
