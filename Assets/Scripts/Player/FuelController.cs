using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FuelController : MonoBehaviour 
{
    private const float MAX_FUEL = 100f;
    private const float MIN_FUEL = 0f;
    private const float SECONDS_TO_SPEND = .1f;

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
        timeToSpend = SECONDS_TO_SPEND;
        currentFuel = MAX_FUEL;
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
        if (timeToSpend <= 0)
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
        currentFuel -= 1;
        timeToSpend = SECONDS_TO_SPEND;
    }
}
