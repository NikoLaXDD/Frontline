using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    
    public List<CardObject> cardList = new();
    public List<CardObject> cardListEnd = new();

    //[SerializeField] private CardScriptable endMoneyMinus;
    //[SerializeField] private CardScriptable endMoneyPlus;

    private int _lastNum;

    private void Awake()
    {
        Instance = this;
        
        var cardLoad = Resources.LoadAll<CardScriptable>("Character").ToList();
        foreach (var cardData in cardLoad)
        {
            var card = new CardObject(cardData);
            cardList.Add(card);
        }
        var cardLoadEnd = Resources.LoadAll<CardScriptable>("EndCard").ToList();
        foreach (var cardData in cardLoadEnd)
        {
            var card = new CardObject(cardData);
            cardListEnd.Add(card);
        }
    }

    public CardObject GetCard()
    {
        var num = Random.Range(0, cardList.Count);
        return cardList[num];
    }
}
