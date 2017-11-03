using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelItem : MonoBehaviour 
{
	private void OnTriggerEnter2D(Collider2D collider) 
	{
        if(collider.gameObject.tag == Constants.TagName.PLAYER) 
		{
            gameObject.SetActive(false);
		}
	}
}
