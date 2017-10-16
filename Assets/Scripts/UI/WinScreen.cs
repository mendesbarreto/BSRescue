using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class WinScreen : MonoBehaviour 
{
	public void ContinueButton() 
	{
		SceneManager.LoadScene(Constants.instance.SelectLvlSceneName);
	}
}
