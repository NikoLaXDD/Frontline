using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance;
    
    private bool _isGameOver;
    private string _endingId;
    public CardObject CardReturn { get; set; }
    public EventObject EventReturn { get; set; }
    public string EndingId { get; set; }
    public bool IsGameOver { get; set; }
    
    public GameOver()
    {
        Instance = this;
    }
    
    public void CheckForNextStep()
    {
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] <= 0)
        {
            IsGameOver = true;
            EndingId = "EndMoneyMinus";
        }
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Money] >= 6)
        {
            IsGameOver = true;
            EndingId = "EndMoneyPlus";
        }
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] <= 0)
        {
            IsGameOver = true;
            EndingId = "EndSupMinus";
        }
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Sup] >= 6)
        {
            IsGameOver = true;
            EndingId = "EndSupPlus";
        }
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] <= 0)
        {
            IsGameOver = true;
            EndingId = "EndManpowerMinus";
        }
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Manpower] >= 6)
        {
            IsGameOver = true;
            EndingId = "EndManpowerPlus";
        }
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] <= 0)
        {
            IsGameOver = true;
            EndingId = "EndAmmoMinus";
        }
        if (StatusController.Instance.statsDictionaty[StatusController.StatusType.Ammo] >= 6)
        {
            IsGameOver = true;
            EndingId = "EndAmmoPlus";
        }
    }
    
    public void GetEndCard(string endId)
    {
        foreach (var cardEnd in CardManager.Instance.cardListEnd)
        {
            if (cardEnd.CardId == endId)
            {
                CardReturn = cardEnd;
            }
        }
    }
    
    public void GetEndEvent(string endId)
    {
        foreach (var eventEnd in EventManager.Instance.eventEndList)
        {
            if (eventEnd.EventId == endId)
            {
                EventReturn = eventEnd;
            }
        }
    }

    public void LastCard()
    {
        GetEndCard(EndingId);
        GetEndEvent(EndingId);
        GameManager.Instance.InstantiateCard(CardReturn);
        GameManager.Instance.InstantiateEvent(EventReturn);
    }
}
