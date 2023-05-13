using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModifiableAttribute
{
    [SerializeReference] private float _baseValue;
    public float BaseValue => _baseValue;
    
    [SerializeField, ReadOnly] private float _currentValue;
    public float CurrentValue => _currentValue;

    [SerializeField] private List<Modifier> _modifiers;
    public List<Modifier> Modifiers => _modifiers;

    public void Awake()
    {
        _currentValue = _baseValue;
        _modifiers.Clear();
    }

    public void CalculateValue()
    {
        float newValue = _baseValue;
        
        foreach (Modifier modifier in _modifiers)
        {
            newValue = modifier.GetModifiedValue(newValue);
        }
        
        _currentValue = newValue;
    }

    public void AddModifier(Modifier modifier)
    {
        _modifiers.Add(modifier);
        CalculateValue();
    }

    public void RemoveModifier(Modifier modifier)
    {
        _modifiers.Remove(modifier);
        CalculateValue();
    }
}
