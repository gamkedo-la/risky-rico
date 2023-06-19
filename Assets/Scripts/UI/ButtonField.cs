using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ButtonField : InputField
{
    [SerializeField] private Button _button;

    protected override void HandleInput(InputAction.CallbackContext context)
    {
        _onInput?.Invoke();
        _button.onClick?.Invoke();
    }
}
