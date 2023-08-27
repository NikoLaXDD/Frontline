using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventObject
{
    public string PrefabName { get; set; }

    public int AmmoPlus { get; set; }
    public int ManpowerPlus { get; set; }
    public int MoneyPlus { get; set; }
    public int SupPlus { get; set; }
    
    public int AmmoMinus { get; set; }
    public int ManpowerMinus { get; set; }
    public int MoneyMinus { get; set; }
    public int SupMinus { get; set; }

    public string TextEvent { get; set; }
    
    public EventObject(EventScriptable data)
    {
        PrefabName = data.prefabID;
        AmmoPlus = data.ammoPlus;
        ManpowerPlus = data.manpowerPlus;
        MoneyPlus = data.moneyPlus;
        SupPlus = data.supPlus;
        
        AmmoMinus = data.ammoMinus;
        ManpowerMinus = data.manpowerMinus;
        MoneyMinus = data.moneyMinus;
        SupMinus = data.supMinus;
        
        TextEvent = data.massage;
    }
}
