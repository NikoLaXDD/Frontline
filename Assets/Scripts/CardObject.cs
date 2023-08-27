using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardObject
{
    public string PrefabName { get; set; }
    public Sprite Sprite { get; set; }

    public CardObject(CardScriptable data)
    {
        PrefabName = data.prefabName;
        Sprite = data.sprite;
    }
}
