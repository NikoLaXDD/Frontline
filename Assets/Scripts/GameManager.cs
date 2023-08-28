using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Card cardPrefab;
    [SerializeField] private Transform spawnTransformCard;
    [SerializeField] private TMP_Text textMassage;
    
    
    [Header("Status Bar")]
    [SerializeField] private TMP_Text textMoney;
    [SerializeField] private TMP_Text textSup;
    [SerializeField] private TMP_Text textManpower;
    [SerializeField] private TMP_Text textAmmo;

    [Header("Calendar")]
    [SerializeField] private TMP_Text textDays;
    [SerializeField] private TMP_Text textMonth;
    [SerializeField] private TMP_Text textYears;

    public int Days;
    public int Months;
    public int Years;
    
    public int Manpower;
    public int Money;
    public int Sup;
    public int Ammo;
    
    private bool _isEnded;

    public EventObject _currentEvent;
    public CardObject _currentCard;

    public EventObject _lastEvent;
    public CardObject _lastCard;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;

        Manpower = 3;
        Money = 3;
        Sup = 3;
        Ammo = 3;

        Days = 1;
        Months = 1;
        Years = 2123;
    }
    
    private void Start()
    {
        
    }

    public void InstantiateCard()
    {
        CalendarController();
        
        if (_currentCard != null)
        {
            _lastCard = _currentCard;
        }

        _currentCard = CardManager.Instance.GetCard();

        if (_currentCard == _lastCard)
        {
            _currentCard = CardManager.Instance.GetCard();
            _lastCard = _currentCard;
        }
        
        var card = Instantiate(cardPrefab, spawnTransformCard);
        card.SetData(_currentCard);

        if (_currentEvent != null)
        {
            _lastEvent = _currentEvent;
        }
        
        _currentEvent = EventManager.Instance.GetEvent();

        if (_currentEvent == _lastEvent)
        {
            _currentEvent = EventManager.Instance.GetEvent();
            _lastEvent = _currentEvent;
        }
        
        textMassage.text = _currentEvent.TextEvent;

        try
        {
            SaveLoadController.Instance.Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void InstantiateCard(CardObject cardSpawned)
    {
        CalendarController();
        
        var card = Instantiate(cardPrefab, spawnTransformCard);
        card.SetData(cardSpawned);

        try
        {
            SaveLoadController.Instance.Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void InstantiateEvent(EventObject eventSpawned)
    {
        _currentEvent = eventSpawned;
        textMassage.text = _currentEvent.TextEvent;
    }

    public void AnswerYes()
    {
        Manpower += _currentEvent.ManpowerPlus;
        Money += _currentEvent.MoneyPlus;
        Sup += _currentEvent.SupPlus;
        Ammo += _currentEvent.AmmoPlus;
        UpdateStatusBar();
    }

    public void AnswerNo()
    {
        Manpower += _currentEvent.ManpowerMinus;
        Money += _currentEvent.MoneyMinus;
        Sup += _currentEvent.SupMinus;
        Ammo += _currentEvent.AmmoMinus;
        UpdateStatusBar();
    }

    public void UpdateStatusBar()
    {
        textMoney.text = Money.ToString();
        textSup.text = Sup.ToString();
        textManpower.text = Manpower.ToString();
        textAmmo.text = Ammo.ToString();
        CheckForNextStep();
    }

    private void CheckForNextStep()
    {
        if (Money <= 0 || Money >= 6)
        {
            _isEnded = true;
            Debug.Log("Ты проебал");
            return;
        }
        if (Sup <= 0 || Sup >= 6)
        {
            _isEnded = true;
            Debug.Log("Ты проебал");
            return;
        }
        if (Manpower <= 0 || Manpower >= 6)
        {
            _isEnded = true;
            Debug.Log("Ты проебал");
            return;
        }
        if (Ammo <= 0 || Ammo >= 6)
        {
            _isEnded = true;
            Debug.Log("Ты проебал");
            return;
        }

        Days++;
    }

    public void CalendarController()
    {
        if (Days >= 31)
        {
            Months++;
        }

        if (Months >= 12)
        {
            Years++;
        }
        
        textDays.text = Days.ToString();
        textMonth.text = Months.ToString();
        textYears.text = Years.ToString();
    }

    public bool EndGame()
    {
        return _isEnded;
    }
}
