using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modifier
{
    [SerializeField] protected Operator _operator;
    public Operator Operator => _operator;

    [SerializeReference] protected float _value;
    public float Value => _value;

    [SerializeField] protected AttributeType _targetAttribute;
    public AttributeType TargetAttribute => _targetAttribute;

    [SerializeField] protected DurationType _durationType;

    [SerializeField] protected float _duration;
    public float Duration => _duration;

    [SerializeField, ReadOnly] protected List<ModifiableAttribute> _listeners = new List<ModifiableAttribute>();
    public List<ModifiableAttribute> Listeners => _listeners;

    protected void OnValidate()
    {
        SignalListeners();
    }

    public void SetValue(float value)
    {
        _value = value;
        SignalListeners();
    }

    public void SetDuration(float value)
    {
        _duration = value;
        SignalListeners();
    }

    public void SetDurationType(DurationType value)
    {
        _durationType = value;
        SignalListeners();
    }

    public void AddListener(ModifiableAttribute listener)
    {
        _listeners.Add(listener);
    }

    protected void SignalListeners()
    {
        foreach (ModifiableAttribute listener in _listeners)
        {
            listener.CalculateValue();
        }
    }

    public virtual float ApplyModifier(float value)
    {
        float newValue = value;

        switch (Operator)
        {
            case Operator.ADD:
                return newValue += _value;
                break;
            case Operator.SUBTRACT:
                return newValue -= _value;
                break;
            case Operator.MULTIPLY:
                return newValue *= _value;
                break;
            case Operator.DIVIDE:
                return newValue /= _value;
                break;
            case Operator.SET:
                return newValue = _value;
                break;
        }

        return newValue;
    }
}


