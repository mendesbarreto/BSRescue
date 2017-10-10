using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public Canvas DeathScreen {
		get { return deathScreen; }
		set { deathScreen = value; }
	}

	[SerializeField]
	private Canvas deathScreen;

	// Use this for initialization
	void Start () {
		deathScreen.enabled = false;
	}

	// check collision
	private void OnCollisionEnter2D (Collision2D collision) {

		if (collision.gameObject.tag == MainGame.instance.FloorTag) {
			Destroy (gameObject);
			deathScreen.enabled = true;

		}
	}
}
