using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectList<T> : ScriptableObject
{
    [Tooltip("The items included in this list")]
    [SerializeField] private List<T> _elements = new List<T>();
    public List<T> Elements => _elements;

    [Tooltip("The maximum number of elements allowed in this list")]
    [SerializeField] int _maxLength = 0;
    public int MaxLength => _maxLength;

    public delegate void AddElement(T element);
    public event AddElement OnAddElement;

    public void Add(T element)
    {
        if (_elements.Count < _maxLength && !_elements.Contains(element))
        {
            _elements.Add(element);
        }
    }

    public void Remove(T element)
    {
        if (_elements.Count > 0 && _elements.Contains(element))
        {
            _elements.Remove(element);
        }
    }

    public void Clear()
    {
        _elements.Clear();
    }
}
