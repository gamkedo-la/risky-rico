using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DungeonManager : MonoBehaviour
{
    [Header("PLAYER SETTINGS")]
    [SerializeField] private PlayerAttributes _player;
    [SerializeField] private IntVariable _score;
    [SerializeField] private IntVariable _ammo;

    [Header("CURSE SETTINGS")]
    [SerializeField] private BoolVariable _randomCursesEnabled;
    [SerializeField] private CurseList _allCurses;
    [SerializeField] private CurseList _playerCurses;

    [Header("WEAPON SETTINGS")]
    [SerializeField] private BoolVariable _randomWeaponsEnabled;
    [SerializeField] private WeaponList _allWeapons;
    [SerializeField] private WeaponList _playerWeapons;

    void Awake()
    {
        // activate difficulty settings on dungeon start
        _player.CurseSlots.Clear();
        if (_randomCursesEnabled.Value)
        {
            Debug.Log("Random Curses Activated");
            // get random curses from the allCurses list and add them to the player's list
            for (int i = 0; i < _playerCurses.MaxLength; i++)
            {
                CurseData randomCurse = _allCurses.Elements[Random.Range(0, _allCurses.Elements.Count)];
                _playerCurses.Add(randomCurse);
            }
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
            _playerWeapons.Clear();
            foreach (WeaponData weapon in randomList)
            {
                _playerWeapons.Add(weapon);
            }

            // set the player's current weapon to the first weapon in the acquired list
            _player.SetCurrentWeapon(_playerWeapons.Elements[0]);
        }

        // reset player values to the default
        _score.Value = 0;
        _ammo.Value = 9;
    }
}
