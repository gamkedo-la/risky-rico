using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DifficultyMenuController : MonoBehaviour
{
    [Header("DIFFICULTY PARAMETERS")]
    [SerializeField] private DifficultyCalculation _totalDifficultyCalculation;
    [SerializeField] private FloatVariable _baseEnemySpeed;
    [SerializeField] private FloatVariable _maxEnemyCount;
    [SerializeField] private BoolVariable _randomCurses;
    [SerializeField] private BoolVariable _randomAbilities;

    [Header("FIELDS")]
    [SerializeField] private SliderSOVariable _speedSlider;
    [SerializeField] private SliderSOVariable _countSlider;
    [SerializeField] private ToggleSOVariable _randomCurseToggle;
    [SerializeField] private ToggleSOVariable _randomWeaponToggle;

    [Header("STORES")]
    [SerializeField] private PlayerMoneyStore _playerMoneyStore;

    [Header("EVENTS")]
    [SerializeField] private GameEvent _onClose;

    public void ApplyChanges()
    {
        _speedSlider.UpdateValue();
        _countSlider.UpdateValue();
        _randomCurseToggle.UpdateValue();
        _randomWeaponToggle.UpdateValue();
    }
    public void AcceptChanges()
    {
        // accept the cost of the difficulty changes and close the menu
        int cost = (int)_totalDifficultyCalculation.TotalCost;
        if (_playerMoneyStore.CanAfford(cost))
        {
            _playerMoneyStore.SpendMoney(cost);
            _onClose?.Raise();
            ServiceLocator.Instance.Get<AudioManager>().PlaySoundFromDictionary("Purchase");
            ApplyChanges();
            return;
        }

        // give feedback if the player cannot afford the cost of the difficulty change
        ServiceLocator.Instance.Get<AudioManager>().PlaySoundFromDictionary("Denied");
    }

    public void RejectChanges()
    {
        _onClose?.Raise();
    }
}
