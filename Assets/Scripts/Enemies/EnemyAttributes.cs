using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "EnemyAttributes", menuName = "Enemies/Enemy Attributes", order = 1)]
public class EnemyAttributes : AttributeSet
{
    [Header("Speed")]
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;
    
    [SerializeField] private float _rotationFrequency;
    public float RotationFrequency => _rotationFrequency;


    [Header("Health")]
    [SerializeField] private int _xHealth;
    public int XHealth => _xHealth;
    [SerializeField] private int _yHealth;
    public int YHealth => _yHealth;


    [Header("Movement Style")]
    [SerializeField] private float _swerveAmplitude;
    public float SwerveAmplitude => _swerveAmplitude;
    
    [SerializeField] private float _swervePeriod;
    public float SwervePeriod => _swervePeriod;
    
    [SerializeField] private float _swerveFrequency;
    public float SwerveFrequency => _swerveFrequency;

    [SerializeField] private bool _strafingEnabled;
    public bool StrafingEnabled => _strafingEnabled;


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
        
    }
}
