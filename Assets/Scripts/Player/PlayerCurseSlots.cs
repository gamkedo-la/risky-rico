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
        _player.ApplyCurse(curse);
    }

    private void DeactivateCurse(CurseModifiers curse)
    {
        _player.RemoveCurse(curse);
    }

    public void RemoveCurse(CurseModifiers curse)
    {
        if (_curses.Contains(curse))
        {
            _curses.Remove(curse);
            DeactivateCurse(curse);
        }
    }

    public void AddCurse(CurseModifiers curse)
    {
        if (!_curses.Contains(curse) && _curses.Count < _maxSlotCount)
        {
            _curses.Add(curse);
            ActivateCurse(curse);
        }
    }
}
