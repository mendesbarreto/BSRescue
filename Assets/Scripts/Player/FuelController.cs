using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelController : MonoBehaviour 
{
    private PlayerGameStatus playerGameStatus;
    private InputController inputController;

    [SerializeField]
    private float currentFuel;

    private float timeToSpend;

    public float CurrentFuel
    {
        get { return currentFuel; }
        set { currentFuel = value; }
    }

	private void Start()
    {
        LoadResources();
	}
	
	private void Update()
    {
        SetUseFuel();
	}

    private void LoadResources()
    {
        timeToSpend = Constants.Fuel.SECONDS_TO_SPEND;
        currentFuel = Constants.Fuel.MAX_FUEL;
        playerGameStatus = GetComponent<PlayerGameStatus>();
        inputController = GetComponent<InputController>();
    }

    private void SetUseFuel()
    {
        if(playerGameStatus.GameStart)
        {
            CheckToSpendFuel();
        }
    }

    private void CheckToSpendFuel()
    {
        if (inputController.PressKeyToPlay)
        {
            TimerToSpendFuel();
        }
    }

    private void TimerToSpendFuel()
    {
        if (timeToSpend <= Constants.Fuel.MIN_FUEL)
        {
            SpendFuel();
        }
        else
        {
            timeToSpend -= Time.deltaTime;
        }
    }

    private void SpendFuel()
    {
        currentFuel -= Constants.Fuel.FUEL_PER_SECONDS;
        timeToSpend = Constants.Fuel.SECONDS_TO_SPEND;
    }
}
