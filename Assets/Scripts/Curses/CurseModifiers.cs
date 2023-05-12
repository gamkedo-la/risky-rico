using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "CurseModifiers", menuName = "Curses/CurseModifiers", order = 1)]
public class CurseModifiers : ScriptableObject
{
    #region Basic Curse Information

    [Header("INFO")]
    [Tooltip("The name of the item the player will see on the UI")]
    [SerializeField] private string _name;
    public string Name => _name;

    [Tooltip("Text meant to describe the curse's functionality and add humor")]
    [TextArea(15,20)]
    [SerializeField] private string _description;
    public string Description => _description;

    #endregion

    #region Curse Stats

    [Header("MODIFIERS")]
    [Tooltip("How much it will increase the player's firing rate with all weapons")]
    [SerializeField] private FloatModifier _firingRateEffect;
    public FloatModifier FiringRateEffect => _firingRateEffect;

    [Tooltip("How much it will increase the player's max ammo cap")]
    [SerializeField] private IntModifier _ammoCapacityEffect;
    public IntModifier AmmoCapacityEffect => _ammoCapacityEffect;

    [Tooltip("How much damage it will deal to enemies")]
    [SerializeField] private IntModifier _damageEffect;
    public IntModifier DamageEffect => _damageEffect;

    [Tooltip("How many extra bullets the player will fire with each shot")]
    [SerializeField] private IntModifier _bulletCountEffect;
    public IntModifier BulletCountEffect => _bulletCountEffect;

    [Tooltip("How much it will increase the player's walk/run movment speed")]
    [SerializeField] private FloatModifier _movementSpeedEffect;
    public FloatModifier MovementSpeedEffect => _movementSpeedEffect;

    [Tooltip("How much it will raise the limit of the player's max score multiplier")]
    [SerializeField] private IntModifier _scoreMultiplierEffect;
    public IntModifier ScoreMultiplierEffect => _scoreMultiplierEffect;

    [Tooltip("How long the item's effect will last from the moment of activation")]
    [SerializeField] private float _effectDuration;
    public float EffectDuration => _effectDuration;

    #endregion
    
    #region Visuals and Sound

    [Header("GRAPHICS")]
    [Tooltip("Default image for the item in the dungeons and the shop")]
    [SerializeField] private Sprite _image;
    public Sprite Image => _image;
    
    [Header("SOUNDS")]
    [Tooltip("Sound to play when the item appears in a dungeon")]
    [SerializeField] private AudioClip _spawnSound;
    public AudioClip SpawnSound => _spawnSound;

    [Tooltip("Sound to play when the player picks up the item")]
    [SerializeField] private AudioClip _collectSound;
    public AudioClip CollectSound => _collectSound;

    #endregion
}
