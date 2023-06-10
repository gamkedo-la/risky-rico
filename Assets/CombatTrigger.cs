using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class CombatTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObjectCollection _collidableObjects;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (_collidableObjects.Contains(collision.gameObject))
        {
            _spawner.SetActive(true);
            _exit.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
