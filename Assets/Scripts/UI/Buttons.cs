using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    [SerializeField]
    private GameObject loading;

    public GameObject Loading
    {
        get { return loading; }
        set { loading = value; }
    }

    private Text loadingText;

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        loadingText = loading.GetComponent<Text>();
        loadingText.enabled = false;
    }

    public void PlayPress()
    {
        SceneManager.LoadScene(Constants.SceneName.SELECT_LVL);
    }

    public void MenuPress()
    {
        SceneManager.LoadScene(Constants.SceneName.MAIN_MENU);
    }

    public void CreditPress()
    {
        SceneManager.LoadScene(Constants.SceneName.CREDITS);
    }

    public void QuitPress()
    {
        Application.Quit();   
    }

    public void SelectedLvlPress(string numberLvl)
    {
        string nameScenelvl = Constants.SceneName.LVL + numberLvl;

        loadingText.enabled = true;
        SceneManager.LoadScene(nameScenelvl);
    }

    public void RestartPress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
