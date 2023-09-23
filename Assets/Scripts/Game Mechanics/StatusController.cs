using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    public static StatusController Instance;

    public StatusController()
    {
        Instance = this;
    }

    public enum StatusType
    {
        Money,
        Sup,
        Manpower,
        Ammo
    }

    public Dictionary<StatusType, int> statsDictionaty = new Dictionary<StatusType, int>()
    {
        { StatusType.Money, 3 },
        { StatusType.Sup, 3 },
        { StatusType.Manpower, 3 },
        { StatusType.Ammo, 3 }
    };
}
