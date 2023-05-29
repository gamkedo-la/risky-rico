using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogLine
{
    [TextArea(15,20)]
    [SerializeField] private string _content;
    public string Content => _content;
}
