using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSequence.asset", menuName = "Content/Dialog")]
public class DialogSequence : ScriptableObject
{
   [SerializeField] private List<DialogLine> lines = new List<DialogLine>();
}
