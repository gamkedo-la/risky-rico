using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerCurseSlots : MonoBehaviour
{
    [Header("Slots")]
    [SerializeField] private List<CurseParameters> _curses = new List<CurseParameters>();
    [SerializeField] private int _maxSlotCount = 3;
    
    [Header("Player")]
    [SerializeField] private PlayerParameters _player;

    private void ActivateCurse(CurseParameters curse)
    {
        Debug.Log("Activating: " + curse.Name);
        _player.ApplyCurse(curse);
    }

    private void DeactivateCurse(CurseParameters curse)
    {
        _player.RemoveCurse(curse);
    }

    public void RemoveCurse(CurseParameters curse)
    {
        if (_curses.Contains(curse))
        {
            _curses.Remove(curse);
            DeactivateCurse(curse);
        }
    }

    public void AddCurse(CurseParameters curse)
    {
        if (!_curses.Contains(curse) && _curses.Count < _maxSlotCount)
        {
            _curses.Add(curse);
            ActivateCurse(curse);
        }
    }
}
