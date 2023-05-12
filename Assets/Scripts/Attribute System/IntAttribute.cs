using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IntAttribute : BaseModifiableAttribute<int>
{
    [Range(0, 10)] protected int _baseValue;
}
