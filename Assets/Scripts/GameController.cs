using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{

    public static GameController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple instances of GameController!");
        }

        instance = this;

        DontDestroyOnLoad(transform.gameObject);
    }
}
