using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionField : InputField
{
    [SerializeField] private TMP_Text _valueTextObject;
    [SerializeField] private List<string> _values;
    [SerializeField] private int _valueIndex = 0;

    protected void Awake()
    {
        if (_labelTextObject)
        {
            _labelTextObject.text = _label;
        }
   
        UpdateValue();
    }

    protected override bool InputDetected()
    {
        return _input.actions["navigate"].triggered && _input.actions["navigate"].ReadValue<Vector2>().x != 0;
    }

    protected override void HandleInput()
    {
        UpdateValueIndex();
        UpdateValue();
        _onInput?.Invoke();
    }

    void UpdateValueIndex()
    {
        // get next value index
        _valueIndex += (int) _input.actions["navigate"].ReadValue<Vector2>().x;

        // loop to start of the list
        if (_valueIndex > _values.Count - 1)
        {
            _valueIndex = 0;
        }
        
        // loop to end of the list
        if (_valueIndex < 0)
        {
            _valueIndex = _values.Count - 1;
        }
    }

    string GetCurrentValue()
    {
        return _values[_valueIndex];
    } 

    void UpdateValue()
    {
        _valueTextObject.text = GetCurrentValue();
    }
}