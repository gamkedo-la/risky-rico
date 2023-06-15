using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class CombatRoom : MonoBehaviour
{
    [SerializeField] private bool _combatFinished;
    [SerializeField] private List<RoomTransition> _exits;
    [SerializeField] private GameObject _spawnTrigger;
    [SerializeField] private EnemySpawnController _spawnController;
    [SerializeField] private GameObjectCollection _collidableObjects;
    [SerializeField] private SpriteRenderer _background;

    void Awake()
    {
        _combatFinished = false;
        Level currentLevel = ServiceLocator.Instance.Get<LevelManager>().GetCurrentLevel();
        if (currentLevel)
        {
            _background.sprite = currentLevel.Graphics["combat"];
        }
    }

    void Update()
    {
        if (_spawnController.State == SpawnState.STOP)
        {
            _combatFinished = true;
            OpenExits();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_combatFinished && _collidableObjects.Contains(collision.gameObject))
        {
            CloseExits();
        }
    }

    public void CloseExits()
    {
        foreach(RoomTransition exit in _exits)
        {
            exit.open = false;
        }
    }

    public void OpenExits()
    {
        foreach(RoomTransition exit in _exits)
        {
            exit.open = true;
        }

        _spawnTrigger.SetActive(false);
    }
}
