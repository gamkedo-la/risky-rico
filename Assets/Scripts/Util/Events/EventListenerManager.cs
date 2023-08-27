using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

[System.Serializable]
public class EventBundle
{
    public string key;
    public List<GameEvent> events;
    public UnityEvent response;
}

public class EventListenerManager : MonoBehaviour
{
    [SerializeField] private List<EventBundle> _eventBundles = new List<EventBundle>();

    void Awake() 
    {
        foreach(EventBundle bundle in _eventBundles)
        {
            foreach(GameEvent e in bundle.events)
            {
                GameEventListener newListener = gameObject.AddComponent<GameEventListener>();
                newListener.SetEvent(e);
                newListener.SetResponse(bundle.response);
                newListener.Register();
            }
        }
    }
}
