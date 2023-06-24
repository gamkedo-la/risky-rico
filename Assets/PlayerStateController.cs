using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;
    [SerializeField] Shoot _playerShoot;
    [SerializeField] MoveTowardClosest _playerMoveTowardClosest;

    void Awake()
    {
        GameStateManager.OnStateChanged += OnGameStateChanged;
        EnableComponentsBasedOnState(ServiceLocator.Instance.Get<GameStateManager>().State);
    }

    void OnGameStateChanged(GameState state)
    {
        EnableComponentsBasedOnState(state);
    }

    void EnableComponentsBasedOnState(GameState state)
    {
        // _playerShoot.enabled = state == GameState.COMBAT;
        // _playerMoveTowardClosest.enabled = state == GameState.COMBAT;
    }
}
