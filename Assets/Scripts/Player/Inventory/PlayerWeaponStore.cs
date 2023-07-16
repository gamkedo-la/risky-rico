using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponStore : MonoBehaviour
{
    #region Inspector Settings
    [Tooltip("The weapons the player currently has access to")]
    [SerializeField] private WeaponList _acquiredWeapons = default(WeaponList);
    public WeaponList AcquiredWeapons => _acquiredWeapons;
    #endregion

    #region Methods
    public void AddWeapon(WeaponData weapon)
    {
        Debug.Log("Adding Weapon ");
        if (!AcquiredWeapons.Elements.Contains(weapon))
        {
            _acquiredWeapons.Add(weapon);
        }
    }

    public void RemoveWeapon(WeaponData weapon)
    {
        if (AcquiredWeapons.Elements.Contains(weapon))
        {
            _acquiredWeapons.Remove(weapon);
        }
    }

    public bool HasWeapon(WeaponData weapon)
    {
        return _acquiredWeapons.Elements.Contains(weapon);
    }
    #endregion
}
