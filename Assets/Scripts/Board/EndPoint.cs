using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour 
{
    [SerializeField]
    private Canvas winScreen;

    public Canvas WinScreen
    {
        get { return winScreen; }
        set { winScreen = value; }
    }

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        winScreen.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == Constants.TagName.PLAYER)
        {
            winScreen.enabled = true;
        }
    }
}
