using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CardDefault cardDefault;
    [SerializeField] private CardEnd cardEnd;
    [SerializeField] private Transform spawnTransformCard;
    [SerializeField] private TMP_Text textMassage;
    
    public Action AnswerNoAction { get; set; }
    public Action AnswerYesAction { get; set; }
    
    public static GameManager Instance;

    private CardObject _currentCard;
    
    private EventObject _lastEvent;
    private CardObject _lastCard;
    
    public TMP_Text TextMassage => textMassage;
    public CardObject CurrentCard { get; set; }

    public EventObject CurrentEvent { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void InstantiateCard()
    {
        StatusBarController.Instance.UpdateStatusBar();
        GameOver.Instance.CheckForNextStep();

        if (GameOver.Instance.IsGameOver)
        {
            GameOver.Instance.LastCard();
            return;
        }
        
        CalendarController.Instance.UpdateCalendar();
        
        if (CurrentCard != null)
        {
            _lastCard = CurrentCard;
        }

        CurrentCard = CardManager.Instance.GetCard();

        if (CurrentCard == _lastCard)
        {
            CurrentCard = CardManager.Instance.GetCard();
            _lastCard = CurrentCard;
        }
        
        var card = Instantiate(cardDefault, spawnTransformCard);
        card.SetData(CurrentCard);
        
        if (CurrentEvent != null)
        {
            _lastEvent = CurrentEvent;
        }
        
        CurrentEvent = EventManager.Instance.GetEvent();

        if (CurrentEvent == _lastEvent)
        {
            CurrentEvent = EventManager.Instance.GetEvent();
            _lastEvent = CurrentEvent;
        }
        
        TextMassage.text = CurrentEvent.TextEvent;

        try
        {
            SaveLoadController.Instance.Save();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        StatusBarController.Instance.UpdateStatusBar();
        CalendarController.Instance.DaysControl();
        GameOver.Instance.CheckForNextStep();
    }

    public void InstantiateCard(CardObject cardSpawned)
    {
        var card = Instantiate(cardEnd, spawnTransformCard);
        card.SetData(cardSpawned);
    }

    public void InstantiateEvent(EventObject eventSpawned)
    {
        CurrentEvent = eventSpawned;
        TextMassage.text = eventSpawned.TextEvent;
    }
}