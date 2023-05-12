using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Player/PlayerAttributes", order = 1)]
public class PlayerAttributes : ScriptableObject
{
    #region Stats
    [Header("Stats")]
    [SerializeField] private FloatAttribute _movementSpeed = default(FloatAttribute);
    public FloatAttribute MovementSpeed => _movementSpeed;

    [SerializeField] private FloatAttribute _firingRate = default(FloatAttribute);
    public FloatAttribute FiringRate => _firingRate;

    [SerializeField] private IntAttribute _damage = default(IntAttribute);
    public IntAttribute Damage => _damage;

    [SerializeField] private float _maxSpecialMeter;
    public float MaxSpecialMeter => _maxSpecialMeter;

    [SerializeField] private IntAttribute _shotCount = default(IntAttribute);
    public IntAttribute ShotCount => _shotCount;
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

    public void ApplyCurse(CurseModifiers curse)
    {
        
    }

    public void RemoveCurse(CurseModifiers curse)
    {
       
    }
}
