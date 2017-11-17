using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelBar : MonoBehaviour 
{
    private RectTransform fuelBar;
    private GameObject player;
    private FuelController fuelController;
    private PlayerGameStatus playerGameStatus;
    [SerializeField]
    private GameObject warningEffect;
    private float warningZone = 25;
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
        warningEffect.SetActive(false);

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
        if (fuelController.CurrentFuel <= warningZone && warningEffect.activeInHierarchy == false)
        {
            warningEffect.SetActive(true);
        } else if (fuelController.CurrentFuel > warningZone && warningEffect.activeInHierarchy == true)
        {
            warningEffect.SetActive(false);
        }
        fuelBar.sizeDelta = new Vector2(WidthFuelBar(), heightFuelBar);
      
    }

    private float WidthFuelBar()
    {
        float levelFuel = Constants.Fuel.MAX_FUEL - fuelController.CurrentFuel;

        return levelFuel;
    }
}
