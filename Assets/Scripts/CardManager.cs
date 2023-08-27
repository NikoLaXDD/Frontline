using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    
    private List<CardObject> _cardList = new();

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
            _cardList.Add(card);
        }
    }

    public CardObject GetCard()
    {
        var num = Random.Range(0, _cardList.Count);
        return _cardList[num];
    }
}
