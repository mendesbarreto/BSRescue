using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelController : MonoBehaviour 
{
    private float currentFuel;

    public float CurrentFuel
    {
        get { return currentFuel; }
        set { currentFuel = value; }
    }

    private float TIME_OUT = 0;

    private PlayerGameStatus playerGameStatus;
    private InputController inputController;
    private Death death;

    private float timeToSpend;

	private void Start()
    {
        LoadResources();
	}
	
	private void Update()
    {
        SetUseFuel();

        CheckEndFuel();
	}

    private void LoadResources()
    {
        timeToSpend = Constants.Fuel.SECONDS_TO_SPEND;
        currentFuel = Constants.Fuel.MAX_FUEL;

        playerGameStatus = GetComponent<PlayerGameStatus>();
        inputController = GetComponent<InputController>();
        death = GetComponent<Death>();
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
        if (timeToSpend <= TIME_OUT)
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

    private void CheckEndFuel()
    {
        if (currentFuel <= Constants.Fuel.MIN_FUEL)
        {
            death.DeathPlayer();
        }
    }
}
