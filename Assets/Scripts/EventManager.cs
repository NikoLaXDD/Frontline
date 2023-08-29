using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    
    public List<EventObject> eventList = new();
    public List<EventObject> eventEndList = new();

    private void Awake()
    {
        Instance = this;
        
        var eventDataList = Resources.LoadAll<EventScriptable>("Event").ToList();
        
        foreach (var eventData in eventDataList)
        {
            var eventObj = new EventObject(eventData);
            eventList.Add(eventObj);
        }

        var eventEndDataList = Resources.LoadAll<EventScriptable>("EndEvent").ToList();
        
        foreach (var eventEnd in eventEndDataList)
        {
            var eventObj = new EventObject(eventEnd);
            eventEndList.Add(eventObj);
        }
    }

    public EventObject GetEvent()
    {
        var num = Random.Range(0, eventList.Count);
        return eventList[num];
    }
}