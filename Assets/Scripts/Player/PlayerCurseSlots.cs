using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerCurseSlots : MonoBehaviour
{
    [Header("Slots")]
    [SerializeField] private List<CurseModifiers> _curses = new List<CurseModifiers>();
    [SerializeField] private int _maxSlotCount = 3;
    
    [Header("Player")]
    [SerializeField] private PlayerAttributes _player;

    private void ActivateCurse(CurseModifiers curse)
    {
        Debug.Log("Activating: " + curse.Name);
        AddCurse(curse);
    }

    public void RemoveCurse(CurseModifiers curse)
    {
        if (_curses.Contains(curse))
        {
            _curses.Remove(curse);
            curse.RemoveModifiers(_player);
        }
    }

    public void AddCurse(CurseModifiers curse)
    {
        Debug.Log("Checking curse");
        if (!_curses.Contains(curse) && _curses.Count < _maxSlotCount)
        {
            Debug.Log("Added curse");
            _curses.Add(curse);

            foreach(Modifier mod in curse.Modifiers)
            {
                _player.ApplyModifier(mod);
            }
        }
    }
}
