using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLvl : MonoBehaviour {

    [SerializeField]
    private Canvas loading;

    public Canvas Loading
    {
        get { return loading; }
        set { loading = value; }
    }

    private void Start()
    {
        LoadResources();
    }

    private void LoadResources()
    {
        loading.enabled = false;
    }

    private void OnLevelWasLoaded(int level)
    {
        loading.enabled = true;
    }
}
