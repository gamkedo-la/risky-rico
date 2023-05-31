using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class DifficultyModes : MonoBehaviour
{
    [Tooltip("Determines how quickly enemies will spawn over time")]
    [SerializeField] private FloatReference _spawnRateIntensity;

    [Tooltip("Determines how long a wave of enemies will last")]
    [SerializeField] private FloatReference _maxWaveDuration;

    [Tooltip("Determines how long a rest period between waves of enemies will last")]
    [SerializeField] private FloatReference _maxRestDuration;

    [Tooltip("Flag to indicate the player will receive three random curses before entering a level")]
    [SerializeField] private BoolReference _randomCursesEnabled;
    
    [Tooltip("Flag to indicate the player will receive a random weapon before entering a level")]
    [SerializeField] private BoolReference _randomWeaponsEnabled;
}
