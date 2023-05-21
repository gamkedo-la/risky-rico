using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderField : InputField
{
    
    [SerializeField] private Slider _slider;

    protected override bool InputDetected()
    {
        return _input.actions["navigate"].triggered && _input.actions["navigate"].ReadValue<Vector2>().x != 0;
    }

    protected override void HandleInput()
    {
        _slider.value += _input.actions["navigate"].ReadValue<Vector2>().x * 0.1f;
        _onInput?.Invoke();
    }
}
