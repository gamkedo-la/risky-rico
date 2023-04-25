using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "ItemParameters", menuName = "Items/ItemParameters", order = 1)]
public class ItemParameters : ScriptableObject
{
    #region Basic Item Information

    [Header("Info")]
    [Tooltip("The name of the item the player will see on the UI")]
    [SerializeField] private string _name;
    public string Name => _name;

    [Tooltip("Text meant to describe the items functionality and add humor")]
    [TextArea(15,20)]
    [SerializeField] private string _description;
    public string Description => _description;

    #endregion

    #region Item Stats

    [Header("Stats")]
    [Tooltip("How much it will increase the player's firing rate with all weapons")]
    [SerializeField] private float _firingRateBuff;
    public float FiringRateBuff => _firingRateBuff;

    [Tooltip("How much it will increase the player's max ammo cap")]
    [SerializeField] private int _ammoCapacityBuff;
    public int AmmoCapacityBuff => _ammoCapacityBuff;

    [Tooltip("How much damage it will deal to enemies")]
    [SerializeField] private int _damageBuff;
    public int DamageBuff => _damageBuff;

    [Tooltip("How much it will increase the player's walk/run movment speed")]
    [SerializeField] private float _movementSpeedBuff;
    public float MovementSpeedBuff => _movementSpeedBuff;

    [Tooltip("How much it will raise the limit of the player's max score multiplier")]
    [SerializeField] private int _scoreMultiplierBuff;
    public int ScoreMultiplierBuff => _scoreMultiplierBuff;

    [Tooltip("How long the item's effect will last from the moment of activation")]
    [SerializeField] private float _effectDuration;
    public float EffectDuration => _effectDuration;

    [Tooltip("How much money the item can be sold for")]
    [SerializeField] private int _sellValue;
    public int SellValue => _sellValue;
    
    #endregion

    
    #region Visuals and Sound

    [Header("Graphics")]
    [Tooltip("Default image for the item in the dungeons and the shop")]
    [SerializeField] private Sprite _image;
    public Sprite Image => _image;
    
    [Header("Sounds")]
    [Tooltip("Sound to play when the item appears in a dungeon")]
    [SerializeField] private AudioClip _spawnSound;
    public AudioClip SpawnSound => _spawnSound;

    [Tooltip("Sound to play when the player picks up the item")]
    [SerializeField] private AudioClip _collectSound;
    public AudioClip CollectSound => _collectSound;

    #endregion
}
