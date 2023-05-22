using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSlots : MonoBehaviour
{
    [SerializeField] private PlayerAttributes _player;
    [SerializeField] private PlayerInput _input;
    private int _currentWeaponIndex = 0;

    void Update()
    {
        if (_input.actions["switchweapon"].triggered)
        {
            SwitchWeapons();
        }
    }

    public void SwitchWeapons()
    {
        _currentWeaponIndex += 1;
        if (_currentWeaponIndex == _player.WeaponList.Count)
        {
            _currentWeaponIndex = 0;
        }

        WeaponData nextWeapon = _player.WeaponList[_currentWeaponIndex];

        _player.SetCurrentWeapon(nextWeapon);
    }
}
