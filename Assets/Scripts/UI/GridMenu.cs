using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class GridMenu : Menu
{
    [Header("GRID")]
    [Tooltip("The UI object to represent a cell in the grid")]
    [SerializeField] private GameObject _gridItem;
    private List<GameObject> _gridItems = new List<GameObject>();

    [SerializeField] private GridLayoutGroup _gridLayout;

    void Start()
    {
        base.Start();
        SpawnGrid();
    }

    void Update()
    {
        if (_input.actions["navigate"].triggered)
        {
            int newCursorRow = (int) _input.actions["navigate"].ReadValue<Vector2>().y * -1 * _gridLayout.constraintCount;
            int newCursorColumn = (int) _input.actions["navigate"].ReadValue<Vector2>().x;
            int newCursorIndex = _cursorIndex + newCursorColumn + newCursorRow;
            SetCursorIndex(newCursorIndex);
            SetActiveInput();
        }

         SetCursorPosition();
    }

    void SetCursorPosition()
    {
        if (_fields[_cursorIndex] != null)
        {
            GameObject currentItem = _gridItems[_cursorIndex].gameObject;
            Vector3 currentItemPosition = currentItem.transform.position;
            _cursor.transform.position = currentItemPosition;
        }
    }

    void SpawnGrid()
    {
       foreach (InputField field in _fields)
       {
            GameObject newGridItem = Instantiate(field.gameObject, transform.position, transform.rotation);
            newGridItem.transform.parent = gameObject.transform;
            _gridItems.Add(newGridItem);
            RectTransform rect = newGridItem.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.localScale = new Vector3(1f, 1f, 1f);
            }
       }
    }
}
