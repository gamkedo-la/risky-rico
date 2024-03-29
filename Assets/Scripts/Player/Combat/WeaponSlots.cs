using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSlots : MonoBehaviour
{
    [SerializeField] private PlayerAttributes _player;
    [SerializeField] private WeaponList _acquiredWeapons;
    private int _currentWeaponIndex = 0;

    void OnDisable()
    {
        InputHandler _inputHandler = ServiceLocator.Instance.Get<InputManager>().Inputs();
        _inputHandler.SwitchWeapon().performed -= SwitchWeapon;
    }
    void OnEnable()
    {
        InputHandler _inputHandler = ServiceLocator.Instance.Get<InputManager>().Inputs();
        _inputHandler.SwitchWeapon().performed += SwitchWeapon;
    }

    public void SwitchWeapon(InputAction.CallbackContext context)
    {
        _currentWeaponIndex += 1;
        if (_currentWeaponIndex == _acquiredWeapons.Elements.Count)
        {
            _currentWeaponIndex = 0;
        }

        WeaponData nextWeapon = _acquiredWeapons.Elements[_currentWeaponIndex];

        _player.SetCurrentWeapon(nextWeapon);

        ServiceLocator.Instance.Get<AudioManager>().PlaySoundFromDictionary("SwitchWeapon");
    }
}
