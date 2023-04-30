using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "Player/PlayerParameters", order = 1)]
public class PlayerParameters : ScriptableObject
{
    #region Stats
    [Header("Stats")]
    [SerializeField] private float _movementSpeed;
    public float MovementSpeed => _movementSpeed;

    [SerializeField] private float _firingRate;
    public float FiringRate => _firingRate;

    [SerializeField] private int _damage;
    public int Damage => _damage;

    [SerializeField] private float _maxSpecialMeter;
    public float MaxSpecialMeter => _maxSpecialMeter;
    #endregion

    #region Graphics
    [Header("Graphics")]
    [SerializeField] private Sprite _idleAnimation;
    public Sprite IdleAnimation => _idleAnimation;

    [SerializeField] private Sprite _deathAnimation;
    public Sprite DeathAnimation => _deathAnimation;
    
    [SerializeField] private Sprite _walkAnimation;
    public Sprite WalkAnimation => _walkAnimation;

    [SerializeField] private Sprite _shootAnimation;
    public Sprite ShootAnimation => _shootAnimation;
    #endregion

    #region Sounds
    [Header("Sounds")]
    [SerializeField] private AudioClip _walkSound;
    public AudioClip WalkSound => _walkSound;
    #endregion

    public void ApplyCurse(CurseParameters curse)
    {
        _movementSpeed += curse.MovementSpeedEffect;
        _firingRate += curse.FiringRateEffect;
        _damage += curse.DamageEffect;
    }

    public void RemoveCurse(CurseParameters curse)
    {
        _movementSpeed -= curse.MovementSpeedEffect;
        _firingRate -= curse.FiringRateEffect;
        _damage -= curse.DamageEffect;
    }
}
