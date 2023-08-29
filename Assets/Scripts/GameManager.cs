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

    [HideInInspector] public int Days;
    [HideInInspector] public int Months;
    [HideInInspector] public int Years;
    
    [HideInInspector] public int Manpower;
    [HideInInspector] public int Money;
    [HideInInspector] public int Sup;
    [HideInInspector] public int Ammo;
    
    private bool _isEnded;
    public bool GameOver;

    [HideInInspector] public EventObject _currentEvent;
    [HideInInspector] public CardObject _currentCard;

    [HideInInspector] public EventObject _lastEvent;
    [HideInInspector] public CardObject _lastCard;

    [HideInInspector] private string _endingId;

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
        if (_isEnded)
        {
            textMassage.text = "";
            GameOver = true;
            return;
        }
        
        Manpower += _currentEvent.ManpowerPlus;
        Money += _currentEvent.MoneyPlus;
        Sup += _currentEvent.SupPlus;
        Ammo += _currentEvent.AmmoPlus;
        UpdateStatusBar();
    }

    public void AnswerNo()
    {
        if (_isEnded)
        {
            textMassage.text = "";
            GameOver = true;
            return;
        }
        
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
        if (Money <= 0)
        {
            _isEnded = true;
            _endingId = "EndMoneyMinus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
        }
        if (Money >= 6)
        {
            _isEnded = true;
            _endingId = "EndMoneyPlus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
        }
        if (Sup <= 0)
        {
            _isEnded = true;
            _endingId = "EndSupMinus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
        }
        if (Sup >= 6)
        {
            _isEnded = true;
            _endingId = "EndSupPlus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
        }
        if (Manpower <= 0)
        {
            _isEnded = true;
            _endingId = "EndManpowerMinus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
        }
        if (Manpower >= 6)
        {
            _isEnded = true;
            _endingId = "EndManpowerPlus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
        }
        if (Ammo <= 0)
        {
            _isEnded = true;
            _endingId = "EndAmmoMinus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
        }
        if (Ammo >= 6)
        {
            _isEnded = true;
            _endingId = "EndAmmoPlus";
            GetEndCard(_endingId);
            GetEndEvent(_endingId);
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

    public void GetEndCard(string endId)
    {
        foreach (var cardEnd in CardManager.Instance.cardListEnd)
        {
            if (cardEnd.CardId == endId)
            {
                InstantiateCard(cardEnd);
            }
        }
    }

    public void GetEndEvent(string endId)
    {
        foreach (var eventEnd in EventManager.Instance.eventEndList)
        {
            if (eventEnd.EventId == endId)
            {
                InstantiateEvent(eventEnd);
            }
        }
    }
}
