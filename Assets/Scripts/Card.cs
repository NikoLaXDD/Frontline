using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card : MonoBehaviour
{
    [SerializeField] private string cardId;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text characterName;

    public void SetData(CardObject cardOData)
    {
        icon.sprite = cardOData.Sprite;
        characterName.text = cardOData.PrefabName;
    }
}