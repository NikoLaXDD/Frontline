using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardObject
{
    public string PrefabName { get; set; }
    public Sprite Sprite { get; set; }

    public string CardId { get; set; }

    public CardObject(CardScriptable data)
    {
        CardId = data.cardId;
        PrefabName = data.prefabName;
        Sprite = data.sprite;
    }
}
