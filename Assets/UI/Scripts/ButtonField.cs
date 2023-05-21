using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonField : InputField
{
    [SerializeField] private Button _button;

    protected override bool InputDetected()
    {
        return _input.actions["interact"].triggered;
    }

    protected override void HandleInput()
    {
        _onInput?.Invoke();
        _button.onClick?.Invoke();
    }
}
