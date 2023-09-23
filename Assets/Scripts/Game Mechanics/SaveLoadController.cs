using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.IO;
using File = System.IO.File;

public class SaveLoadController : MonoBehaviour
{
    public static SaveLoadController Instance;

    public SaveLoadStruct saveLoadStruct { get; set; }
    
    public void Start()
    {
        Instance = this;
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        saveLoadStruct = JsonUtility.FromJson<SaveLoadStruct>(File.ReadAllText(Application.streamingAssetsPath + "SaveLoadController.json"));
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] = saveLoadStruct.SavedManpower;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] = saveLoadStruct.SavedMoney;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] = saveLoadStruct.SavedSup;
        StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] = saveLoadStruct.SavedAmmo;
        
        CalendarController.Instance.calendar[CalendarController.CalendarType.Days] = saveLoadStruct.SavedDays;
        CalendarController.Instance.calendar[CalendarController.CalendarType.Months] = saveLoadStruct.SavedMonths;
        CalendarController.Instance.calendar[CalendarController.CalendarType.Years] = saveLoadStruct.SavedYears;

        foreach (var loadEvent in EventManager.Instance.eventList)
        {
            if (loadEvent.EventId == saveLoadStruct.IdEvent)
            {
                GameManager.Instance.InstantiateEvent(loadEvent);
            }
        }
        
        foreach (var loadCard in CardManager.Instance.cardList)
        {
            if (loadCard.CardId == saveLoadStruct.IdCard)
            {
                GameManager.Instance.InstantiateCard(loadCard);
            }
        }
        
        StatusBarController.Instance.UpdateStatusBar();
        CalendarController.Instance.DaysControl();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        saveLoadStruct = new SaveLoadStruct()
        {
            SavedManpower = StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower],
            SavedMoney = StatusController.Instance.statsDictionaty[StatusController.StatusType.Money],
            SavedSup = StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup],
            SavedAmmo = StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo],
            
            SavedDays = CalendarController.Instance.calendar[CalendarController.CalendarType.Days],
            SavedMonths = CalendarController.Instance.calendar[CalendarController.CalendarType.Months],
            SavedYears = CalendarController.Instance.calendar[CalendarController.CalendarType.Years],
            IdCard = GameManager.Instance.CurrentCard.CardId,
            IdEvent = GameManager.Instance.CurrentEvent.EventId,
        };
        
        File.WriteAllText(Application.streamingAssetsPath + "SaveLoadController.json", JsonUtility.ToJson(saveLoadStruct));
    }

    public struct SaveLoadStruct
    {
        public int SavedManpower;
        public int SavedMoney;
        public int SavedSup;
        public int SavedAmmo;

        public int SavedDays;
        public int SavedMonths;
        public int SavedYears;

        public string IdCard;
        public string IdEvent;
    }
}