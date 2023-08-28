using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("Menu Element")]
    [SerializeField] private Button buttonLoadGame;
    [SerializeField] private Button buttonStartGame;
    [SerializeField] private Button buttonExitGame;
    [SerializeField] private GameObject panelMenu;

    public static GameMenu Instance;
    
    void Awake()
    {
        Instance = this;
        
        buttonLoadGame.onClick.AddListener(ClickButtonLoad);
        buttonStartGame.onClick.AddListener(ClickButtonStart);
    }

    private void ClickButtonLoad()
    {
        var state = panelMenu.activeSelf;
        panelMenu.SetActive(!state);
        try
        {
            SaveLoadController.Instance.Load();
            GameManager.Instance.UpdateStatusBar();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private void ClickButtonStart()
    {
        var state = panelMenu.activeSelf;
        panelMenu.SetActive(!state);
        GameManager.Instance.InstantiateCard();
        GameManager.Instance.Ammo = 3;
        GameManager.Instance.Manpower = 3;
        GameManager.Instance.Sup = 3;
        GameManager.Instance.Money = 3;
        GameManager.Instance.Days = 1;
        GameManager.Instance.Months = 1;
        GameManager.Instance.Years = 2123;
        GameManager.Instance.UpdateStatusBar();
    }

    private void ClickButtonExit()
    {
        //Exit
    }
}
