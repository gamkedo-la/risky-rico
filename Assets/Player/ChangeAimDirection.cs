using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeAimDirection : MonoBehaviour
{
    [SerializeField]
    private Vector2Variable _direction;

    [SerializeField]
    private PlayerInput _playerInput;

    void Update() 
    {
        if (_playerInput.actions["aimhorizontal"].triggered || _playerInput.actions["aimvertical"].triggered)
        {
            _direction.Value = new Vector2(_playerInput.actions["aimhorizontal"].ReadValue<float>(), _playerInput.actions["aimvertical"].ReadValue<float>());
        }
    }
}
