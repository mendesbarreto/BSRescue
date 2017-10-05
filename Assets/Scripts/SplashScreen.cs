using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SplashScreen : MonoBehaviour {

	private int secondsToChange = 2;

	// Use this for initialization
	private void Start () {

		StartCoroutine ("Countdown");
	}

	// wait some seconds to change scene
	private IEnumerator Countdown () {
		yield return new WaitForSeconds (secondsToChange);
		SceneManager.LoadScene ("MainMenu");
	}
}
