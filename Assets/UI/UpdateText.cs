using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ScriptableObjectArchitecture;
using TMPro;

public class UpdateText : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    
    [Header("FLOAT VALUE")]
    [SerializeField] private bool _useFloat = false;
    [SerializeField, HideCustomDrawer] private FloatVariable _value;

    [Header("STRING VALUE")]
    [SerializeField] private bool _useString = false;
    [SerializeField, HideCustomDrawer] private StringReference _stringValue;

    void Update()
    {
        if (_useFloat && _value != null)
        {
            _text.text = "" + _value.Value;
        }

        if (_useString && _stringValue != null)
        {
            _text.text = _stringValue.Value;
        }
    }
}
