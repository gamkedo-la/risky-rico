using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Enemies/Enemy Attributes", order = 1)]
public class EnemyAttributes : AttributeSet
{
    [Header("Speed")]
    [SerializeField] private ModifiableAttribute _moveSpeed;
    public ModifiableAttribute MoveSpeed => _moveSpeed;
    
    [SerializeField] private ModifiableAttribute _rotationFrequency;
    public ModifiableAttribute RotationFrequency => _rotationFrequency;


    [Header("Health")]
    [SerializeField] private ModifiableAttribute _xHealth;
    public ModifiableAttribute XHealth => _xHealth;

    [SerializeField] private ModifiableAttribute _yHealth;
    public ModifiableAttribute YHealth => _yHealth;


    [Header("Movement Style")]
    [SerializeField] private ModifiableAttribute _swerveAmplitude;
    public ModifiableAttribute SwerveAmplitude => _swerveAmplitude;
    
    [SerializeField] private ModifiableAttribute _swervePeriod;
    public ModifiableAttribute SwervePeriod => _swervePeriod;
    
    [SerializeField] private ModifiableAttribute _swerveFrequency;
    public ModifiableAttribute SwerveFrequency => _swerveFrequency;

    [Header("Graphics")]
    [SerializeField] private Sprite _attackAnimation;
    public Sprite AttackAnimation => _attackAnimation;

    [SerializeField] private Sprite _deathAnimation; 
    public Sprite DeathAnimation => _deathAnimation;
    
    
    [Header("Sounds")]
    [SerializeField] private AudioClip _spawnCry;
    public AudioClip SpawnCry => _spawnCry;

    [SerializeField] private AudioClip _deathCry;
    public AudioClip DeathCry => _deathCry;

    public void OnEnable() 
    {
        _attributes.Clear();

        _attributes.Add(_moveSpeed);
        _attributes.Add(_rotationFrequency);
        _attributes.Add(_xHealth);
        _attributes.Add(_yHealth);

        InitAttributes();
    }
}
