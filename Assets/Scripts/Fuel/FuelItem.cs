using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelItem : MonoBehaviour 
{
    private float NUMBER_ADD_FUEL = 10f;
    private float MAX_FUEL = 100f;

    private GameObject player;
    private FuelController fuelController;

    private float maxToAdd;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        player = GameObject.FindGameObjectWithTag(Constants.TagName.PLAYER);
        fuelController = player.GetComponent<FuelController>();

        maxToAdd = MAX_FUEL - NUMBER_ADD_FUEL;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
	{
        if(collider.gameObject.tag == Constants.TagName.PLAYER) 
		{
            AddFuel();
            gameObject.SetActive(false);
		}
	}

    private void AddFuel()
    {
        if (fuelController.CurrentFuel >= maxToAdd)
        {
            fuelController.CurrentFuel = MAX_FUEL;
        }
        else
        {
            fuelController.CurrentFuel += NUMBER_ADD_FUEL;
        }
    }
}
