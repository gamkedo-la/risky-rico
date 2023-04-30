using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "CurseParameters", menuName = "Curses/CurseParameters", order = 1)]
public class CurseParameters : ScriptableObject
{
    #region Basic Curse Information

    [Header("Info")]
    [Tooltip("The name of the item the player will see on the UI")]
    [SerializeField] private string _name;
    public string Name => _name;

    [Tooltip("Text meant to describe the items functionality and add humor")]
    [TextArea(15,20)]
    [SerializeField] private string _description;
    public string Description => _description;

    #endregion

    #region Curse Stats

    [Header("Stats")]
    [Tooltip("How much it will increase the player's firing rate with all weapons")]
    [SerializeField] private float _firingRateEffect;
    public float FiringRateEffect => _firingRateEffect;

    [Tooltip("How much it will increase the player's max ammo cap")]
    [SerializeField] private int _ammoCapacityEffect;
    public int AmmoCapacityEffect => _ammoCapacityEffect;

    [Tooltip("How much damage it will deal to enemies")]
    [SerializeField] private int _damageEffect;
    public int DamageEffect => _damageEffect;

    [Tooltip("How many extra bullets the player will fire with each shot")]
    [SerializeField] private int _bulletCountEffect;
    public int BulletCountEffect => _bulletCountEffect;

    [Tooltip("How much it will increase the player's walk/run movment speed")]
    [SerializeField] private float _movementSpeedEffect;
    public float MovementSpeedEffect => _movementSpeedEffect;

    [Tooltip("How much it will raise the limit of the player's max score multiplier")]
    [SerializeField] private int _scoreMultiplierEffect;
    public int ScoreMultiplierEffect => _scoreMultiplierEffect;

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
