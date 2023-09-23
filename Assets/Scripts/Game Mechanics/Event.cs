using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] private TMP_Text textMassage;

    public void SetData(EventObject eventData)
    {
        textMassage.text = eventData.TextEvent;
    }
}
