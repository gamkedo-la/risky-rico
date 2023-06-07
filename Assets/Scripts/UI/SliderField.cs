using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderField : InputField
{
    [SerializeField] private Slider _slider;

    [Range(0f, 10f)]
    [SerializeField] private float _incrementValue = 0.1f;

    protected override bool InputDetected()
    {
        return _input.actions["navigate"].triggered && _input.actions["navigate"].ReadValue<Vector2>().x != 0;
    }

    protected override void HandleInput()
    {
        _slider.value += _input.actions["navigate"].ReadValue<Vector2>().x * _incrementValue;
        _onInput?.Invoke();
    }


    public float GetCurrentValue()
    {
        return _slider.value;
    }

    public float GetMaxValue()
    {
        return _slider.maxValue;
    }

    public float GetMinValue()
    {
        return _slider.minValue;
    }
}
