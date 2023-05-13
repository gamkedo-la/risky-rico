using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Modifier
{
    [SerializeField] private Operator _operator;
    public Operator Operator => _operator;

    [SerializeReference] private float _value;
    public float Value => _value;

    [SerializeField] private AttributeType _targetAttribute;
    public AttributeType TargetAttribute => _targetAttribute;

    [SerializeField] private DurationType _durationType;

    [SerializeField] private float _duration;
    public float Duration => _duration;

    public float ApplyModifier(float value)
    {
        float newValue = value;

        switch (Operator)
        {
            case Operator.ADD:
                newValue += _value;
                break;

            case Operator.SUBTRACT:
                newValue -= _value;
                break;

            case Operator.MULTIPLY:
                newValue *= _value;
                break;

            case Operator.DIVIDE:
                newValue /= _value;
                break;

            case Operator.SET:
                newValue = _value;
                break;
        }

        return newValue;
    }
}


