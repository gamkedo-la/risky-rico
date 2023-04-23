using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class SpawnEnemyGroup : MonoBehaviour
{
    [SerializeField] private EnemyParameters _parameters;
    [SerializeField] private Health _health;
    [SerializeField] private MoveInOwnDirection _movement;

    void Awake()
    {
        
    }

    void Update()
    {

    }
}
