using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModifiableAttribute<T>
{
    [SerializeReference] protected T _baseValue;
    public T BaseValue => _baseValue;
    
    [SerializeField, ReadOnly] protected T _currentValue;
    public T CurrentValue => _currentValue;

    [SerializeField] protected List<BaseModifier<T>> _modifiers;
    public List<BaseModifier<T>> Modifiders => _modifiers;

    protected void Awake()
    {
        _currentValue = _baseValue;
        _modifiers = new List<BaseModifier<T>>();
    }

    protected void OnValidate()
    {
        CalculateValue();
    }

    public void CalculateValue()
    {
        T newValue = _baseValue;
        
        foreach (BaseModifier<T> modifier in _modifiers)
        {
            newValue = modifier.ApplyModifier(newValue);
        }
        
        _currentValue = newValue;
    }

    public void AddModifier(BaseModifier<T> modifier)
    {
        _modifiers.Add(modifier);

        if (!modifier.Listeners.Contains(this))
        {
            modifier.AddListener(this);
        }
        
        CalculateValue();
    }
}
