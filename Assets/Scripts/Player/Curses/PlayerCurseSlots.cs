using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerCurseSlots : MonoBehaviour
{
    [Header("Slots")]
    [SerializeField] private List<CurseData> _curses = new List<CurseData>();
    public List<CurseData> Curses => _curses;
    [SerializeField] private int _maxSlotCount = 3;
    
    [Header("Player")]
    [SerializeField] private PlayerAttributes _player;

    private void ActivateCurse(CurseData curse)
    {
        AddCurse(curse);
    }

    public void RemoveCurse(CurseData curse)
    {
        if (_curses.Contains(curse))
        {
            _curses.Remove(curse);
             foreach(Modifier mod in curse.Modifiers)
            {
                _player.RemoveModifier(mod);
            }
        }
    }

    public void AddCurse(CurseData curse)
    {
        if (!_curses.Contains(curse) && _curses.Count < _maxSlotCount)
        {
            _curses.Add(curse);
            foreach(Modifier mod in curse.Modifiers)
            {
                _player.ApplyModifier(mod);
            }
        }
    }
}
