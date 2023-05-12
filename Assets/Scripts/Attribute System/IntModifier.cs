using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IntModifier : BaseModifier<int> 
{
    [Range(0, 10)] protected int _value;

    public override int ApplyModifier(int value)
    {
        int newValue = value;

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
