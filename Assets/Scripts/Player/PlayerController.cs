using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private MoveInOwnDirection _movementScript;
    private PlayerInput _input;

    void Start() 
    {
        _movementScript = GetComponent<MoveInOwnDirection>();
        _input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        float _moveDirectionX = _input.actions["move"].ReadValue<Vector2>().x;
        float _moveDirectionY = _input.actions["move"].ReadValue<Vector2>().y;
        Vector2 _moveDirection = new Vector2(_moveDirectionX, _moveDirectionY);
        _movementScript.SetDirection(_moveDirection);
    }

}
