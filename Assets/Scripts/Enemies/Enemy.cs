using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyParameters _parameters;
    [SerializeField] private Health _health;
    [SerializeField] private MoveInOwnDirection _movement;
    [SerializeField] private SpriteRenderer _renderer;

    void Awake()
    {
        // get necesssary components
        _renderer = gameObject.GetComponent<SpriteRenderer>();
        _health = gameObject.GetComponent<Health>();
        _movement = gameObject.GetComponent<MoveInOwnDirection>();

        // apply parameters to individual components
        SetParameters(_parameters);
    }

    public void SetParameters(EnemyParameters parameters)
    {
        _parameters = parameters;
        _movement.SetSpeed(_parameters.MoveSpeed);
        _renderer.sprite = _parameters.AttackAnimation;
        _health.SetHealth(_parameters.XHealth, _parameters.YHealth);
    }
}