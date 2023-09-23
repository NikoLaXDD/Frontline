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
            StatusBarController.Instance.UpdateStatusBar();
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
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] = 3;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] = 3;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] = 3;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] = 3;
        CalendarController.Instance.calendar[CalendarController.CalendarType.Days] = 1;
        CalendarController.Instance.calendar[CalendarController.CalendarType.Months] = 1;
        CalendarController.Instance.calendar[CalendarController.CalendarType.Years] = 2123;
        StatusBarController.Instance.UpdateStatusBar();
        CalendarController.Instance.DaysControl();
    }

    private void ClickButtonExit()
    {
        //Exit
    }
}
