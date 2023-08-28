using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class CardScriptable : ScriptableObject
{
    public string cardId;
    
    public string prefabName;
    public Sprite sprite;
}
