using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelItem : MonoBehaviour 
{
    private GameObject player;
    private FuelController fuelController;
    private AudioSource audioFuel;

    private float maxToAdd;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        player = GameObject.FindGameObjectWithTag(Constants.TagName.PLAYER);
        fuelController = player.GetComponent<FuelController>();
        audioFuel = player.GetComponent<AudioSource>();

        maxToAdd = Constants.Fuel.MAX_FUEL - Constants.Fuel.NUMBER_ADD_FUEL;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
	{
        if(collider.gameObject.tag == Constants.TagName.PLAYER) 
		{
            audioFuel.Play();
            AddFuel();
            gameObject.SetActive(false);
		}
	}

    private void AddFuel()
    {
        if (fuelController.CurrentFuel >= maxToAdd)
        {
            fuelController.CurrentFuel = Constants.Fuel.MAX_FUEL;
        }
        else
        {
            fuelController.CurrentFuel += Constants.Fuel.NUMBER_ADD_FUEL;
        }
    }
}
