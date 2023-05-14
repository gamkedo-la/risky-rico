using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Player/PlayerAttributes", order = 1)]
public class PlayerAttributes : AttributeSet, IResetOnExitPlay
{
    #region Combat
    [Header("COMBAT STATS")]
    [SerializeField] private ModifiableAttribute _movementSpeed = default(ModifiableAttribute);
    public ModifiableAttribute MovementSpeed => _movementSpeed;

    [SerializeField] private ModifiableAttribute _firingRate = default(ModifiableAttribute);
    public ModifiableAttribute FiringRate => _firingRate;

    [SerializeField] private ModifiableAttribute _damage = default(ModifiableAttribute);
    public ModifiableAttribute Damage => _damage;

    [SerializeField] private ModifiableAttribute _shotCount = default(ModifiableAttribute);
    public ModifiableAttribute ShotCount => _shotCount;
    #endregion

    #region Graphics
    [Header("GRAPHICS")]
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
    [Header("SOUNDS")]
    [SerializeField] private AudioClip _walkSound;
    public AudioClip WalkSound => _walkSound;
    #endregion

    #region Methods
    public void ResetAttributeList()
    {
        _attributes.Clear();

        _attributes.Add(_movementSpeed);
        _attributes.Add(_firingRate);
        _attributes.Add(_damage);
        _attributes.Add(_shotCount);

        InitAttributes();
    }

    public void ResetOnExitPlay()
    {
        ResetAttributeList();
    }

    public void OnEnable()
    {
        ResetAttributeList();
    }

    public void ApplyModifier(Modifier mod)
    {
        switch(mod.TargetAttribute)
        {
            case AttributeType.MOVEMENT_SPEED:
                _movementSpeed.AddModifier(mod);
                break;

            case AttributeType.DAMAGE:
                _firingRate.AddModifier(mod);
                break;

            case AttributeType.FIRING_RATE:
                _damage.AddModifier(mod);
                break;

            case AttributeType.SHOT_COUNT:
                _shotCount.AddModifier(mod);
                break;
        }
    }

    public void RemoveModifier(Modifier mod)
    {
        switch(mod.TargetAttribute)
        {
            case AttributeType.MOVEMENT_SPEED:
                _movementSpeed.RemoveModifier(mod);
                break;

            case AttributeType.DAMAGE:
                _firingRate.RemoveModifier(mod);
                break;

            case AttributeType.FIRING_RATE:
                _damage.RemoveModifier(mod);
                break;

            case AttributeType.SHOT_COUNT:
                _shotCount.RemoveModifier(mod);
                break;
        }
    }
    #endregion
}
