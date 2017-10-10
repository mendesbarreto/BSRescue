using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLvl : MonoBehaviour {

	// on click button lvl
	public void ClickSelectLvl (string numberLvl) {
		string nameScenelvl = MainGame.instance.LvlScene + numberLvl;

		SceneManager.LoadScene (nameScenelvl);
	}
}
