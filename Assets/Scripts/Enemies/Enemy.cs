using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAttributes _parameters;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private MoveTowardClosest _movement;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private EnemyRotate _rotationBehavior;
    [SerializeField] private EnemySwerve _swerveBehavior;

    void Awake()
    {
        // get necesssary components
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _health = gameObject.GetComponent<EnemyHealth>();
        _movement = gameObject.GetComponent<MoveTowardClosest>();
        _rotationBehavior = gameObject.GetComponent<EnemyRotate>();
        _swerveBehavior = gameObject.GetComponent<EnemySwerve>();

        // apply parameters to individual components
        SetAttributes(_parameters);
    }

    public void SetAttributes(EnemyAttributes parameters)
    {
        _parameters = parameters;
        _renderer.sprite = _parameters.AttackAnimation;
        _health.SetHealth(_parameters.XHealth.CurrentValue, _parameters.YHealth.CurrentValue);
        _rotationBehavior.enemy = parameters;
        _swerveBehavior.enemy = parameters;
        _movement.SetSpeed(parameters.MoveSpeed.CurrentValue);
    }
}
