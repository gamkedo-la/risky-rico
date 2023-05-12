using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseModifier<T>
{
    [SerializeReference] protected T _value;
    public T Value => _value;

    [SerializeField] protected Operator _operator;
    public Operator Operator => _operator;

    [SerializeField] protected DurationType _durationType;

    [SerializeField] protected float _duration;
    public float Duration => _duration;

    [SerializeField, ReadOnly] protected List<BaseModifiableAttribute<T>> _listeners = new List<BaseModifiableAttribute<T>>();
    public List<BaseModifiableAttribute<T>> Listeners => _listeners;

    protected void OnValidate()
    {
        SignalListeners();
    }

    public void SetValue(T value)
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

    public void AddListener(BaseModifiableAttribute<T> listener)
    {
        _listeners.Add(listener);
    }

    protected void SignalListeners()
    {
        foreach (BaseModifiableAttribute<T> listener in _listeners)
        {
            listener.CalculateValue();
        }
    }

    public virtual T ApplyModifier(T value)
    {
        return value;
    }
}


