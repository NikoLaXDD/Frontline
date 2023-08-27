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
        GameManager.Instance.Manpower = saveLoadStruct._savedManpower;
        GameManager.Instance.Money = saveLoadStruct._savedMoney;
        GameManager.Instance.Sup = saveLoadStruct._savedSup;
        GameManager.Instance.Ammo = saveLoadStruct._savedAmmo;
        
        GameManager.Instance.Days = saveLoadStruct._savedDays;
        GameManager.Instance.Months = saveLoadStruct._savedMonths;
        GameManager.Instance.Years = saveLoadStruct._savedYears;
        
        GameManager.Instance.UpdateStatusBar();
        GameManager.Instance.CalendarManager();
    }

    [ContextMenu("Save")]
    public void Save()
    {
        saveLoadStruct = new SaveLoadStruct()
        {
            _savedManpower = GameManager.Instance.Manpower,
            _savedMoney = GameManager.Instance.Money,
            _savedSup = GameManager.Instance.Sup,
            _savedAmmo = GameManager.Instance.Ammo,
            
            _savedDays = GameManager.Instance.Days,
            _savedMonths = GameManager.Instance.Months,
            _savedYears = GameManager.Instance.Years
        };
        
        File.WriteAllText(Application.streamingAssetsPath + "SaveLoadController.json", JsonUtility.ToJson(saveLoadStruct));
    }

    struct SaveLoadStruct
    {
        public int _savedManpower;
        public int _savedMoney;
        public int _savedSup;
        public int _savedAmmo;
        
        public int _savedDays;
        public int _savedMonths;
        public int _savedYears;
    }
}