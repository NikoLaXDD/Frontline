using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    
    private List<EventObject> _eventList = new();

    private void Awake()
    {
        Instance = this;
        
        var eventDataList = Resources.LoadAll<EventScriptable>("Event").ToList();
        
        foreach (var eventData in eventDataList)
        {
            var eventObj = new EventObject(eventData);
            _eventList.Add(eventObj);
        }
    }

    public EventObject GetEvent()
    {
        var num = Random.Range(0, _eventList.Count);
        return _eventList[num];
    }
}