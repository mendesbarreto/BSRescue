using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelBar : MonoBehaviour 
{
    private RectTransform fuelBar;
    private GameObject player;
    private FuelController fuelController;
    private PlayerGameStatus playerGameStatus;

    private float heightFuelBar;

	private void Start () 
    {
        LoadResources();
	}
	
	private void Update () 
    {
        CheckWinScreen();
	}

    private void LoadResources()
    {
        player = GameObject.FindGameObjectWithTag(Constants.TagName.PLAYER);

        fuelBar = GetComponent<RectTransform>();
        fuelController = player.GetComponent<FuelController>();
        playerGameStatus = player.GetComponent<PlayerGameStatus>();

        heightFuelBar = fuelBar.rect.height;
    }

    private void CheckWinScreen()
    {
        if(!playerGameStatus.WinGameStatus)
        {
            ChangeFuel();
        }
    }

    private void ChangeFuel()
    {
        fuelBar.sizeDelta = new Vector2(ChangeWithCurrentFuel(), heightFuelBar);
    }

    private float ChangeWithCurrentFuel()
    {
        float levelFuel = Constants.Fuel.MAX_FUEL - fuelController.CurrentFuel;

        return levelFuel;
    }
}
