using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using ScriptableObjectArchitecture;

public class ShopMenu : MonoBehaviour
{
    [Header("PLAYER DATA")]
    private PlayerMoneyStore _playerMoneyStore;
    private PlayerWeaponStore _playerWeaponStore;
    private PlayerAmmoStore _playerAmmoStore;

    [Header("ITEM DATA")]
    [SerializeField] private GridMenu _gridMenu;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private TMP_Text _itemPrice;

    [Header("WEAPON STATS")]
    [SerializeField] private TMP_Text _weaponAmmo;
    [SerializeField] private TMP_Text _weaponDamage;
    [SerializeField] private GameObject _statsContainer;

    [Header("EVENTS")]
    [SerializeField] private GameEvent _onShopClose;

    void Start()
    {
        // player data
        _playerMoneyStore = GetComponent<PlayerMoneyStore>();
        _playerAmmoStore = GetComponent<PlayerAmmoStore>();
        _playerWeaponStore = GetComponent<PlayerWeaponStore>();

        // inputs
        InputHandler _inputHandler = ServiceLocator.Instance.Get<InputManager>().Inputs();
        _inputHandler.Exit().performed += CloseShop;
        _inputHandler.Interact().performed += SelectItem;
    }

    void Update()
    {
        InputField currentInput = _gridMenu.GetActiveInput();

        // view item details
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

        CheckForOwnedItems();
    }

    void SelectItem(InputAction.CallbackContext context)
    {
        InputField currentInput = _gridMenu.GetActiveInput();

        // attempt to purchase item
        if (currentInput != null && currentInput is ShopItemField)
        {
            AttemptPurchase((ShopItemField)currentInput);
        }
    }

    void CloseShop(InputAction.CallbackContext context)
    {
        _onShopClose?.Raise();
    }

    bool ItemCanBePurchased(ItemData item)
    {
        // can you afford the item?
        bool canAfford = _playerMoneyStore.CanAfford(item.Price);

        // if the item provides ammo, do you already have max ammo?
        bool tooMuchAmmo = _playerAmmoStore.MaxAmmo() && item.AmmoAmount > 0;

        // do you already own the item?
        bool ownItem = item.WeaponData != null && _playerWeaponStore.HasWeapon(item.WeaponData);

        // purchasing criteria
        return canAfford && !ownItem && !tooMuchAmmo;
    }

    void CheckForOwnedItems()
    {
        foreach (ShopItemField field in _gridMenu.Fields)
        {
            ItemData item = field.ItemData;
            if (!ItemCanBePurchased(item))
            {
                GameObject shopItemGO = field.gameObject;
                float transparency = 0.5f;
                Color color = new Color(1f, 1f, 1f, transparency);
                shopItemGO.GetComponent<CanvasRenderer>().SetColor(color);
            }
        }
    }

    void AttemptPurchase(ShopItemField selectedItem)
    {
        ItemData item = selectedItem.ItemData;

        // attempt purchase based on criteria
        bool canBePurchased = ItemCanBePurchased(item);
        if (canBePurchased)
        {
            PurchaseItem(item);
            ServiceLocator.Instance.Get<AudioManager>().PlaySoundFromDictionary("Purchase");
            return;
        }

        ServiceLocator.Instance.Get<AudioManager>().PlaySoundFromDictionary("Denied");
    }

    void PurchaseItem(ItemData item)
    {
        _playerMoneyStore.SubtractOnHandMoney(item.Price);

        bool isWeapon = item.WeaponData != null;

        if (isWeapon)
        {
            _playerWeaponStore.AddWeapon(item.WeaponData);
            return;
        }

        _playerAmmoStore.GainAmmo(item.AmmoAmount);
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
        for (int i = 0; i < maxStatNumber; i++)
        {
            statString += "+";
        }

        // get relevant weapon base stats
        int weaponAmmo = weapon.BaseAmmoUsage;
        int weaponDamage = weapon.BaseDamage;

        // display the stats as a portion of the maximum stat string
        _weaponAmmo.text = "AMMO USAGE: " + weaponAmmo;
        _weaponDamage.text = "DAMAGE: " + weaponDamage;
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
