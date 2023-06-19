using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    [SerializeField] private Image _secondaryWeapon;
    [SerializeField] private GameObject _curseSlotsContainer;
    [SerializeField] private PlayerAttributes _player;
    [SerializeField] private PlayerCurseSlots _curseSlots;
    [SerializeField] private GameObject _curseImage;


    void Awake()
    {
        if (_player.WeaponList.Count > 1)
        {
            _secondaryWeapon.sprite = _player.WeaponList[1].EquipIcon;
        } 

        foreach(CurseData curse in _curseSlots.Curses)
        {
            GameObject newCurseSlot = Instantiate(_curseImage);
            newCurseSlot.transform.SetParent(_curseSlotsContainer.transform, false);
            newCurseSlot.GetComponent<Image>().sprite = curse.Image;
        }
    }
}
