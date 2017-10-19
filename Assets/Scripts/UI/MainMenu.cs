using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class MainMenu : MonoBehaviour 
{
    [SerializeField]
    private Button playButton;
 
    [SerializeField]
    private Button codeButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private Canvas codeScreen;

    public Button PlayButton
    {
        get { return playButton; }
        set { playButton = value; }
    }

    public Button CodeButton
    {
        get { return codeButton; }
        set { codeButton = value; }
    }

    public Button QuitButton
    {
        get { return quitButton; }
        set { quitButton = value; }
    }

    public Canvas CodeScreen
    {
        get { return codeScreen; }
        set { codeScreen = value; }
    }

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        codeScreen.enabled = false;
        VerifyToUnlockButtonStart();
    }

    private void Update()
    {
        UnlockButtonsIfCloseCodeScreen();
    }

    private void UnlockButtonsIfCloseCodeScreen()
    {
        if(!codeScreen.enabled)
        {
            EnableButtonsMainMenu();
            VerifyToUnlockButtonStart();
        }
    }

    private void EnableButtonsMainMenu()
    {
        quitButton.interactable = true;
        codeButton.interactable = true;
    }

    private void VerifyToUnlockButtonStart()
    {
        if (MainGame.instance.GameStats == Constants.Code.NUMBER_TO_UNLOCK_PLAY_BUTTON)
        {
            playButton.interactable = true;
        }
        else
        {
            playButton.interactable = false;
        }
    }

    public void PlayPress() 
	{
        SceneManager.LoadScene(Constants.SceneName.SELECT_LVL);
	}

    public void CodePress()
    {
        codeScreen.enabled = true;
        DisableButtonsMainMenu();
    }

    private void DisableButtonsMainMenu()
    {
        quitButton.interactable = false;
        codeButton.interactable = false;
        playButton.interactable = false;
    }

	public void QuitPress() 
	{
		Application.Quit();
	}
}
