using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("NAVIGATION")]
    [Tooltip("The object used to highlight the current menu item")]
    [SerializeField] private GameObject _cursor;

    [Tooltip("The interactive fields contained in this menu")]
    [SerializeField] private List<InputField> _fields = new List<InputField>();
    [SerializeField] private int _cursorIndex;
    
    [Header("INPUT")]
    [Tooltip("The input module used for navigation")]
    [SerializeField] private PlayerInput _input;

    [Header("TEXT")]
    [Tooltip("The text to explain the current menu item's functionality")]
    [SerializeField] private TMP_Text _explanationText;

    void Start()
    {
        _cursorIndex = 0;

        foreach (InputField field in _fields)
        {
            field.SetInput(_input);
        }

        SetActiveInput();
        SetExplanationText(GetCurrentField().Description);
    }

    void Update()
    {
        if (_input.actions["navigate"].triggered)
        {
            int newCursorPosition = _cursorIndex + (int) _input.actions["navigate"].ReadValue<Vector2>().y * -1;
            SetCursorPosition(newCursorPosition);
            SetActiveInput();
            SetExplanationText(GetCurrentField().Description);
        }
    }

    void SetCursorPosition(int position)
    {
        // get the attempted new cursor position
        _cursorIndex = position;

        // loop back to start of menu list
        if (_cursorIndex > _fields.Count - 1)
        {
            _cursorIndex = 0;
        }

        // loop to end of menu list
        if (_cursorIndex < 0)
        {
            _cursorIndex = _fields.Count - 1;
        }

        // move the menu cursor to the current field
        if (_fields[_cursorIndex] != null)
        {
            GameObject currentField = _fields[_cursorIndex].gameObject;
            Vector3 currentFieldPosition = currentField.transform.position;

            Vector3 cursorPosition = _cursor.transform.position;
            _cursor.transform.position = new Vector3(cursorPosition.x, currentFieldPosition.y, cursorPosition.z);
        }


    }

    void SetActiveInput()
    {
        foreach(InputField field in _fields)
        {
            field.SetInputEnabled(false);
        }

        if (_fields[_cursorIndex] != null)
        {
            _fields[_cursorIndex].SetInputEnabled(true);
        }
    }

    InputField GetCurrentField()
    {
        return _fields[_cursorIndex]; 
    }

    void SetExplanationText(string newText)
    {
        _explanationText.text = newText;
    }
}
