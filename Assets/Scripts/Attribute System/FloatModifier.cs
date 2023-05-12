using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FloatModifier : BaseModifier<float>
{
    [Range(0, 10)] protected float _value;

    public override float ApplyModifier(float value)
    {
        float newValue = value;

        switch(Operator)
        {
            case Operator.ADD:
                newValue += Value;
                break;
            case Operator.SUBTRACT:
                newValue -= Value;
                break;
            case Operator.DIVIDE:
                newValue /= Value;
                break;
            case Operator.MULTIPLY:
                newValue *= Value;
                break;
            case Operator.SET:
                newValue = Value;
                break;
            default:
                break;
        }

        return newValue;
    }
}


