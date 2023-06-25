using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObjectCollection _damagingObjects;
    [SerializeField] private GameEvent _deathEvent;

     void OnTriggerEnter2D(Collider2D other) 
    {
        bool isLethal = (bool) other.gameObject.GetComponent<Bullet>()?.Lethal;
        if (_damagingObjects.Contains(other.gameObject) && isLethal)
        {
            _deathEvent?.Raise();
        }    
    }
}
