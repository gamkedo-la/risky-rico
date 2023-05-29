using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    [Header("ITEM DATA")]
    [SerializeField] private GridMenu _gridMenu;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private TMP_Text _itemPrice;

    [Header("WEAPON STATS")]
    [SerializeField] private TMP_Text _weaponAmmo;
    [SerializeField] private TMP_Text _weaponFiringRate;
    [SerializeField] private TMP_Text _weaponShotCount;
    [SerializeField] private TMP_Text _weaponDamage;
    [SerializeField] private GameObject _statsContainer;

    void Update()
    {
        InputField currentInput = _gridMenu.GetActiveInput();

        if (currentInput != null && currentInput is ShopItemField)
        {
            ShopItemField currentItem = (ShopItemField)currentInput;
            ItemData item = currentItem.ItemData;
            _itemName.text = item.Name;
            _itemDescription.text = item.Description;
            _itemPrice.text = "PRICE: " + item.Price;
            _statsContainer.active = item.WeaponData != null;
            UpdateStatsContainer(item.WeaponData);
        }
    }

    void UpdateStatsContainer(WeaponData weapon)
    {
        // don't update the stats if the container is inactive
        if (!_statsContainer.active || weapon == null)
        {
            return;
        }

        // create a string of "+" signs to represent the maximum quantity of a stat 
        int maxStatNumber = 10;
        string statString = "";
        for(int i = 0; i < maxStatNumber; i++)
        {
            statString += "+";
        }

        // get relevant weapon base stats
        int weaponAmmo = weapon.BaseAmmoCapacity;
        int weaponDamage = weapon.BaseDamage;
        int weaponFiringRate = (int) weapon.BaseFiringRate;
        int weaponShotCount = weapon.BaseBulletCount;

        // display the stats as a portion of the maximum stat string
        _weaponAmmo.text = "AMMO: " + statString.Substring(0, weaponAmmo);
        _weaponDamage.text = "DAMAGE: " + statString.Substring(0, weaponDamage);
        _weaponFiringRate.text = "FIRING RATE: " + statString.Substring(0, weaponFiringRate);
        _weaponShotCount.text = "SHOT COUNT: " + statString.Substring(0, weaponShotCount);
    }

    ShopItemField GetActiveItem()
    {
        ShopItemField currentItem = null;

        foreach (ShopItemField field in _gridMenu.Fields)
        {
            if (field.InputEnabled)
            {
                currentItem = field;
            }
        }

        return currentItem;
    }
}
