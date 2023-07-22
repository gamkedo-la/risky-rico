using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ScriptableObjectArchitecture;

public class StorageMenu : MonoBehaviour
{
    [SerializeField] private PlayerMoneyStore _moneyStore;
    [SerializeField] private int _moneyIncrement;
    [SerializeField] private GameEvent _onClose;

    void OnEnable()
    {
        InputHandler _inputHandler = ServiceLocator.Instance.Get<InputManager>().Inputs();
        _inputHandler.Navigate().performed += ExchangeMoney;
        _inputHandler.Exit().performed += CloseMenu;
    }

    void OnDisable()
    {
        InputHandler _inputHandler = ServiceLocator.Instance.Get<InputManager>().Inputs();
        _inputHandler.Navigate().performed -= ExchangeMoney;
        _inputHandler.Exit().performed -= CloseMenu;
    }

    void ExchangeMoney(InputAction.CallbackContext context)
    {
        // deposit
        if (context.ReadValue<Vector2>().x > 0)
        {
            _moneyStore.DepositMoney(_moneyIncrement);
        }

        // withdraw
        if (context.ReadValue<Vector2>().x < 0)
        {
            _moneyStore.WithdrawMoney(_moneyIncrement);
        }
    }

    void CloseMenu(InputAction.CallbackContext context)
    {
        _onClose?.Raise();
    }

}
