using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Death : MonoBehaviour 
{
	[SerializeField]
	private Canvas deathScreen;

    public Canvas DeathScreen
    {
        get { return deathScreen; }
        set { deathScreen = value; }
    }

	private void Start() 
	{
		deathScreen.enabled = false;
	}

	// check collision
	private void OnCollisionEnter2D(Collision2D collision) 
	{
        if(collision.gameObject.tag == Constants.TagName.FLOOR) 
		{
            DeathPlayer();
		}
	}

    public void DeathPlayer()
    {
        SpecialEffect.instance.Explosion(transform.position);
        Destroy(gameObject);
        deathScreen.enabled = true;
    }
}
