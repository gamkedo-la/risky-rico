using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private GameObjectCollection _transportableObjects;
    [SerializeField] private GameObject _endPoint;
    public bool enabled = false;

    void Awake()
    {
        if (_endPoint != null)
        {
            _endPoint.GetComponent<RoomTransition>().SetEndPoint(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled && _endPoint && _transportableObjects.Contains(collision.gameObject))
        {
            collision.gameObject.transform.position = _endPoint.transform.position;
            RoomTransition otherTransitionPoint = _endPoint.GetComponent<RoomTransition>();
            otherTransitionPoint.enabled = false;
        }
    }
 
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (!enabled && _transportableObjects.Contains(collision.gameObject))
        {
            enabled = true;
        }
    }

    public void SetEndPoint(GameObject endPoint)
    {
        _endPoint = endPoint;
    }
}

