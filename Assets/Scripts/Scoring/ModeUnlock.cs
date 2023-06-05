using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ModeUnlock : MonoBehaviour
{
    [SerializeField] private FloatVariable _score;
    [SerializeField] private FloatVariable _hardModeScore;
    [SerializeField] private FloatVariable _enemySpeed;
    [SerializeField] private FloatVariable _enemyHardmodeSpeed;
}
