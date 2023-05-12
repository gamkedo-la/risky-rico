using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloatAttribute : BaseModifiableAttribute<float>
{
    [Range(0f, 10f)] protected float _baseValue;
}
