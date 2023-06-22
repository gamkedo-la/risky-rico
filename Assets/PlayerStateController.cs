using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] Shoot _playerShoot;

    void Awake()
    {
        GameStateManager.OnStateChanged += OnGameStateChanged;
    }

    void OnGameStateChanged(GameState state)
    {
        Debug.Log("new state");
        Debug.Log(state);

        _playerController.enabled = state == GameState.EXPLORATION;
        _playerShoot.enabled = state == GameState.COMBAT;
    }
}
