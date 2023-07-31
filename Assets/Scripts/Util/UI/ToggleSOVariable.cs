using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ToggleSOVariable : MonoBehaviour
{
    [SerializeField] private BoolVariable _var;
    [SerializeField] private SelectionField _field;

    public void UpdateValue()
    {
        string currentValue = _field.GetCurrentValue();

        _var.Value = currentValue == "ON"; 
    }
}
