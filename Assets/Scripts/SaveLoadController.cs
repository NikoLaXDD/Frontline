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

    private SaveLoadStruct saveLoadStruct;
    public void Start()
    {
        Instance = this;
    }
    
    [ContextMenu("Load")]
    public void Load()
    {
        saveLoadStruct = JsonUtility.FromJson<SaveLoadStruct>(File.ReadAllText(Application.streamingAssetsPath + "SaveLoadController.json"));
        GameManager.Instance.Manpower = saveLoadStruct.SavedManpower;
        GameManager.Instance.Money = saveLoadStruct.SavedMoney;
        GameManager.Instance.Sup = saveLoadStruct.SavedSup;
        GameManager.Instance.Ammo = saveLoadStruct.SavedAmmo;
        
        GameManager.Instance.Days = saveLoadStruct.SavedDays;
        GameManager.Instance.Months = saveLoadStruct.SavedMonths;
        GameManager.Instance.Years = saveLoadStruct.SavedYears;

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
        
        GameManager.Instance.UpdateStatusBar();
        GameManager.Instance.CalendarController();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        saveLoadStruct = new SaveLoadStruct()
        {
            SavedManpower = GameManager.Instance.Manpower,
            SavedMoney = GameManager.Instance.Money,
            SavedSup = GameManager.Instance.Sup,
            SavedAmmo = GameManager.Instance.Ammo,
            
            SavedDays = GameManager.Instance.Days,
            SavedMonths = GameManager.Instance.Months,
            SavedYears = GameManager.Instance.Years,
            IdCard = GameManager.Instance._currentCard.CardId,
            IdEvent = GameManager.Instance._currentEvent.EventId,
        };
        
        File.WriteAllText(Application.streamingAssetsPath + "SaveLoadController.json", JsonUtility.ToJson(saveLoadStruct));
    }

    struct SaveLoadStruct
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