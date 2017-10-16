using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SelectLvl : MonoBehaviour 
{
	// on click button lvl
	public void ClickSelectLvl(string numberLvl) 
	{
        string nameScenelvl = Constants.SceneName.LVL + numberLvl;

		SceneManager.LoadScene(nameScenelvl);
	}
}
