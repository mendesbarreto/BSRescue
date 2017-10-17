using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelBar : MonoBehaviour 
{
    private RectTransform background;
    private GameObject player;
    private FuelController fuelController;
    private PlayerGameStatus playerGameStatus;

    private float positionVerticalBackground;

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
        background = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag(Constants.TagName.PLAYER);
        fuelController = player.GetComponent<FuelController>();
        playerGameStatus = player.GetComponent<PlayerGameStatus>();

        positionVerticalBackground = background.rect.height;
    }

    private void CheckWinScreen()
    {
        if(!playerGameStatus.WinGameBool)
        {
            ChangeBackgroundWidth();
        }
    }

    private void ChangeBackgroundWidth()
    {
        background.sizeDelta = new Vector2(ChangeWithCurrentFuel(), positionVerticalBackground);
    }

    private float ChangeWithCurrentFuel()
    {
        float levelFuel = Constants.Fuel.MAX_FUEL - fuelController.CurrentFuel;

        return levelFuel;
    }
}
