using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using TMPro;

public class InputField : MonoBehaviour
{
    [Header("FIELD INFO")]
    [Tooltip("The name of the input field displayed on the UI")]
    [SerializeField] protected string _label;
    
    [Tooltip("Text to explain what the input does")]
    [SerializeField] protected string _description;
    public string Description => _description; 

    [Tooltip("The text object to hold the label")]
    [SerializeField] protected TMP_Text _labelTextObject;
    
    [Header("CHANGE HANDLING")]
    [Tooltip("The event invoked when a change is made to the input field")]
    [SerializeField] protected UnityEvent _onInput = new UnityEvent();

    protected bool _inputEnabled;

    protected PlayerInput _input;

    protected void Awake()
    {
        if (_labelTextObject)
        {
            _labelTextObject.text = _label;
        }
    }

    protected virtual void HandleInput()
    {
        _onInput?.Invoke();
    }
    
    protected virtual bool InputDetected() 
    {
        return false;
    }

    public void SetInputEnabled(bool toggleValue)
    {
        _inputEnabled = toggleValue;
    }

    public void SetInput(PlayerInput input)
    {
        _input = input;
    }

    void Update()
    {
        if (_inputEnabled && _input != null && InputDetected())
        {
            HandleInput();
        }
    }

}
