using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModifiableAttribute
{
    [SerializeField] protected AttributeType _type;
    public AttributeType Type => _type;

    [SerializeReference] protected float _baseValue;
    public float BaseValue => _baseValue;
    
    [SerializeField, ReadOnly] protected float _currentValue;
    public float CurrentValue => _currentValue;

    [SerializeField] protected List<Modifier> _modifiers;
    public List<Modifier> Modifiers => _modifiers;


    public void Awake()
    {
        _currentValue = _baseValue;
        _modifiers.Clear();
    }

    public void OnValidate()
    {
        CalculateValue();
    }

    public void CalculateValue()
    {
        float newValue = _baseValue;
        
        foreach (Modifier modifier in _modifiers)
        {
            newValue = modifier.ApplyModifier(newValue);
        }
        
        _currentValue = newValue;
    }

    public void AddModifier(Modifier modifier)
    {
        _modifiers.Add(modifier);

        if (!modifier.Listeners.Contains(this))
        {
            modifier.AddListener(this);
        }
        
        CalculateValue();
    }
}
