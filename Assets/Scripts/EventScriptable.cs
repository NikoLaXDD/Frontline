using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 2)]
public class EventScriptable : ScriptableObject
{
    public string prefabID;
    
    public int moneyPlus;
    public int ammoPlus;
    public int supPlus;
    public int manpowerPlus;
    
    public int moneyMinus;
    public int ammoMinus;
    public int supMinus;
    public int manpowerMinus;

    public string massage;
}