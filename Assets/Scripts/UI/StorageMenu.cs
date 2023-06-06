using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StorageMenu : MonoBehaviour
{
    [SerializeField] private PlayerMoneyStore _moneyStore;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private int _moneyIncrement;


    void Update()
    {
        // deposit
        if (_input.actions["navigate"].triggered && _input.actions["navigate"].ReadValue<Vector2>().x > 0)
        {
            _moneyStore.DepositMoney(_moneyIncrement);
        }

        // withdraw
        if (_input.actions["navigate"].triggered && _input.actions["navigate"].ReadValue<Vector2>().x < 0)
        {
            _moneyStore.WithdrawMoney(_moneyIncrement);
        }

        // close menu
        if (_input.actions["cancel"].triggered)
        {
            gameObject.SetActive(false);
        }
    }

}
