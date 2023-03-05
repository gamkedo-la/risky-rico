using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using TMPro;

public class UpdateText : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    [SerializeField] private FloatVariable _value;
    void Update()
    {
        _text.text = "" + _value.Value;
    }
}
