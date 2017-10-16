using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour 
{
	private void OnTriggerEnter2D(Collider2D collider) 
	{
		if(collider.gameObject.tag == Constants.instance.PlayerTagName) 
		{
			Destroy(gameObject);
		}
	}
}
