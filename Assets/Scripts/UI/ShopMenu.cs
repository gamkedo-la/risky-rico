using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private GridMenu _gridMenu;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private TMP_Text _itemPrice;

    void Update()
    {
        InputField currentInput = _gridMenu.GetActiveInput();

        if (currentInput != null && currentInput is ShopItemField)
        {
            ShopItemField currentItem = (ShopItemField)currentInput;
            ItemParameters item = currentItem.ItemData;
            _itemName.text = item.Name;
            _itemDescription.text = item.Description;
            _itemPrice.text = "PRICE: " + item.Price;
        }
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
