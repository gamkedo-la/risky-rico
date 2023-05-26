using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemField : InputField
{
    [SerializeField] private ItemParameters _itemData;
    public ItemParameters ItemData => _itemData;

    void Start()
    {
        Image image = GetComponent<Image>();
        image.sprite = _itemData.Image;
    }
}
