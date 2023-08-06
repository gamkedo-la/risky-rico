using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DungeonManager : MonoBehaviour
{
    [SerializeField] private PlayerAttributes _player;
    [SerializeField] private IntVariable _score;
    [SerializeField] private IntVariable _ammo;
    [SerializeField] private BoolVariable _randomCursesEnabled;
    [SerializeField] private BoolVariable _randomWeaponsEnabled;
    [SerializeField] private WeaponList _allWeapons;
    [SerializeField] private WeaponList _acquiredWeapons;

    void Awake()
    {
        // activate difficulty settings on dungeon start
        if (_randomCursesEnabled.Value)
        {
            Debug.Log("Random Curses Activated");
        }

        if (_randomWeaponsEnabled.Value)
        {
            // randomly pick two weapons from the allWeapons list
            List<WeaponData> randomList = new List<WeaponData>();
            for (int i = 0; i < 2; i++)
            {
                WeaponData randomWeapon = _allWeapons.Elements[Random.Range(0, _allWeapons.Elements.Count)];
                randomList.Add(randomWeapon);
            }

            // replace the elements in the acquired weapons list with the random weapons
            _acquiredWeapons.Clear();
            foreach (WeaponData weapon in randomList)
            {
                _acquiredWeapons.Add(weapon);
            }

            // set the player's current weapon to the first weapon in the acquired list
            _player.SetCurrentWeapon(_acquiredWeapons.Elements[0]);
        }

        // reset player values to the default
        _score.Value = 0;
        _ammo.Value = 9;
        _player.CurseSlots.Clear();
    }
}
