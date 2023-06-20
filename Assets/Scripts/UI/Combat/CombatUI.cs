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
    [SerializeField] private List<GameObject> _curseImageSlots = new List<GameObject>();


    void Update()
    {
        if (_player.CurrentWeapon != null)
        {
            _secondaryWeapon.sprite = _player.CurrentWeapon.EquipIcon;
        } 

        for (int i = 0; i <= _curseSlots.Curses.Count - 1; i++)
        {
            _curseImageSlots[i].GetComponent<Image>().sprite = _curseSlots.Curses[i].Image;
        }
    }
}
