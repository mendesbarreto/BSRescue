using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelBar : MonoBehaviour 
{
    private RectTransform background;
    private GameObject player;
    private FuelController fuelController;

    private float positionVerticalBackground;

	private void Start () 
    {
        LoadResources();
	}
	
	private void Update () 
    {
        ChangeBackgroundWidth();
	}

    private void LoadResources()
    {
        background = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag(Constants.TagName.PLAYER);
        fuelController = player.GetComponent<FuelController>();

        positionVerticalBackground = background.rect.height;
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
