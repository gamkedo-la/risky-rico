using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private GameObjectCollection _transportableObjects;
    [SerializeField] private GameObject _endPoint;
    [SerializeField] private GameEvent _onRoomEnter;
    
    public bool enabled = false;
    public bool open = true;

    void Awake()
    {
        if (_endPoint != null)
        {
            _endPoint.GetComponent<RoomTransition>().SetEndPoint(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (open && enabled && _endPoint && _transportableObjects.Contains(collision.gameObject))
        {
            collision.gameObject.transform.position = _endPoint.transform.position;
            RoomTransition otherTransitionPoint = _endPoint.GetComponent<RoomTransition>();
            otherTransitionPoint.enabled = false;
        }
    }
 
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!enabled && _transportableObjects.Contains(collision.gameObject))
        {
            enabled = true;
            _onRoomEnter?.Raise();
        }
    }

    public void SetEndPoint(GameObject endPoint)
    {
        _endPoint = endPoint;
    }
}

