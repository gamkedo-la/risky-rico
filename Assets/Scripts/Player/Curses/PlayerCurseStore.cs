using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerCurseStore : MonoBehaviour
{
    [Header("Slots")]
    [SerializeField] private CurseList _curses;

    [Header("Player")]
    [SerializeField] private PlayerAttributes _player;

    void OnEnable()
    {
        _curses.OnAddCurse += ActivateCurse;
    }

    void OnDisable()
    {
        _curses.OnAddCurse -= ActivateCurse;
    }

    private void ActivateCurse(CurseData curse)
    {
        foreach (Modifier mod in curse.Modifiers)
        {
            _player.ApplyModifier(mod);
        }
    }

    public void RemoveCurse(CurseData curse)
    {
        if (_curses.Elements.Contains(curse))
        {
            _curses.Remove(curse);
            foreach (Modifier mod in curse.Modifiers)
            {
                _player.RemoveModifier(mod);
            }
        }
    }

    public void AddCurse(CurseData curse)
    {
        if (!_curses.Elements.Contains(curse))
        {
            _curses.Add(curse);
            foreach (Modifier mod in curse.Modifiers)
            {
                _player.ApplyModifier(mod);
            }
        }
    }
}
