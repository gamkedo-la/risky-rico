using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Weapon/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    #region Basic Weapon Information

    [Header("Basic Information")]
    [Tooltip("The name of the weapon the player will see on the UI")]
    [SerializeField] private string _name;
    public string Name => _name;

    [Tooltip("Text meant to describe the weapon's functionality and add humor")]
    [TextArea(15,20)]
    [SerializeField] private string _description;
    public string Description => _description;

    #endregion

    #region Weapon Stats

    [Header("Combat Stats")]
    [Tooltip("How quickly the weapon can fire (measured in shots per second)")]
    [Range(0.1f, 10f)]
    [SerializeField] private float _baseFiringRate;
    public float baseFiringRate => _baseFiringRate;
    
    [Tooltip("How much damage the weapon deals on contact")]
    [Range(0, 4)]
    [SerializeField] private int _baseDamage;
    public int baseDamage => _baseDamage;

    [Tooltip("Maximum ammo for the weapon. Can be raised by other item effects")]
    [Range(1, 10)]
    [SerializeField] private int _baseAmmoCapacity;
    public int BaseAmmoCapacity => _baseAmmoCapacity;
    
    [Tooltip("How many bullets come out when fired. Must fire at least 1 bullet")]
    [Range(1, 4)]
    [SerializeField] private int _baseBulletCount;
    public int BaseBulletCount => _baseBulletCount;

    [Tooltip("The special effect to apply on contact or when fired")]
    [SerializeField] private AmmoEffect _effect;
    public AmmoEffect Effect => _effect;
    #endregion

    #region Graphics and Sound

    [Header("Graphics and Sound")]
    [Tooltip("The icon displayed when viewed in the Shop UI")]
    [SerializeField] private Sprite _storeIcon;
    public Sprite StoreIcon => _storeIcon;

    [Tooltip("The icon displayed when in combat")]
    [SerializeField] private Sprite _equipIcon;
    public Sprite EquipIcon => _equipIcon;

    [Tooltip("The sound played when the weapon fires")]
    [SerializeField] private AudioClip _firingSound;
    public AudioClip FiringSound => _firingSound;

    #endregion

}
