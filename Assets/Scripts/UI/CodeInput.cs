using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeInput : MonoBehaviour 
{
    [SerializeField]
    private Canvas codeScreen;

    [SerializeField]
    private Text messageInput;

    public Text MessageInput
    {
        get { return messageInput; }
        set { messageInput = value; }
    }

    public Canvas CodeScreen
    {
        get { return codeScreen; }
        set { codeScreen = value; }
    }

    private InputField codeInputField;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        codeInputField = GetComponent<InputField>();
    }

    public void SubmitPress()
    {
        if(codeInputField.text == Constants.Code.TEXT_RESET)
        {
            ResetCode();
        }
        else if(codeInputField.text == Constants.Code.TEXT_CODE)
        {
            EnterCorrectCode();
        }
        else
        {
            EnterIncorrectCode();
        }
    }

    private void ResetCode()
    {
        MainGame.instance.GameStats = Constants.Code.NUMBER_TO_LOCK_PLAY_BUTTON;
        MainGame.instance.SetNumberKeyGameStats();

        PlayerPrefs.DeleteAll();

        messageInput.text = Constants.Code.TEXT_MESSAGE_RESET + MainGame.instance.GameStats;

        codeScreen.enabled = false;
    }

    private void EnterCorrectCode()
    {
        MainGame.instance.GameStats = Constants.Code.NUMBER_TO_UNLOCK_PLAY_BUTTON;

        codeInputField.text = "";
        messageInput.text = "";

        codeScreen.enabled = false;
    }

    private void EnterIncorrectCode()
    {
        messageInput.text = Constants.Code.TEXT_CODE_INCORRECT;
    }
}
