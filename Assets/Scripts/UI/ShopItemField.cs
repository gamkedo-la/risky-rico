using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemField : InputField
{
    [SerializeField] private ItemData _itemData;
    public ItemData ItemData => _itemData;

    void Start()
    {
        Image image = GetComponent<Image>();
        image.sprite = _itemData.Image;
    }

    public void SetItemData(ItemData data)
    {
        _itemData = data;
    }
}
