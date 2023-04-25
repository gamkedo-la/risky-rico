using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerMoneyStore : MonoBehaviour
{
    #region Inspector Settings
    
    [Header("Money Sources")]
    [Tooltip("How much money the player is currently holding")]
    [SerializeField] private IntReference _onHandMoney;

    [Tooltip("How much money the player has stored in the shop")]
    [SerializeField] private IntReference _depositedMoney;
    
    [Header("Limits")]
    [Tooltip("The maximum amount of money the player can hold")]
    [SerializeField] private int _onHandMoneyLimit;

    [Tooltip("The maximum amount of money the player can store at the shop")]
    [SerializeField] private int _depositMoneyLimit;

    #endregion

    #region Methods

    #region On-Hand Money Methods
    public void SetOnHandMoney(int amount)
    {
        _onHandMoney.Value = amount;
        _onHandMoney.Value = Mathf.Clamp(_onHandMoney.Value, 0, _onHandMoneyLimit);
    }

    public void AddOnHandMoney(int amount)
    {
        _onHandMoney.Value += amount;
        _onHandMoney.Value = Mathf.Clamp(_onHandMoney.Value, 0, _onHandMoneyLimit);
    }

    public void SubtractOnHandMoney(int amount)
    {
        _onHandMoney.Value -= amount;
        _onHandMoney.Value = Mathf.Clamp(_onHandMoney.Value, 0, _onHandMoneyLimit);
    }
    #endregion

    #region Deposited Money Methods
    public void SetDepositedMoney(int amount)
    {
        _depositedMoney.Value = amount;
        _depositedMoney.Value = Mathf.Clamp(_depositedMoney.Value, 0, _depositMoneyLimit);
    }

    public void DepositMoney(int amount)
    {
        if (amount <= _onHandMoney.Value && _onHandMoney.Value + amount <= _depositMoneyLimit)
        {
            SubtractOnHandMoney(amount);
            _depositedMoney.Value += amount;
        }
    }

    public void WithdrawMoney(int amount)
    {
        if (amount <= _depositedMoney.Value)
        {
            AddOnHandMoney(amount);
            _depositedMoney.Value -= amount;
        }
    }
    #endregion

    #endregion
}
