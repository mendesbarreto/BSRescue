using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLvl : MonoBehaviour 
{
	// on click button lvl
	public void ClickSelectLvl (string numberLvl) 
	{
		string nameScenelvl = Constants.instance.LvlSceneName + numberLvl;

		SceneManager.LoadScene (nameScenelvl);
	}
}
