using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class EnemySpawnController : MonoBehaviour
{
    #region Inspector Info
    #region Controller State
    [Header("CONTROLLER STATE")]
    [SerializeField] private SpawnState _state = SpawnState.WAVE;
    [SerializeField] private bool _loopWaves = false;
    #endregion

    #region Wave Data
    [Header("WAVE DATA")]
    [SerializeField] private List<WaveData> _waves = new List<WaveData>();
    [Tooltip("Counts up until it reaches the current wave's max wave duration")]
    [SerializeField, ReadOnly] private float _waveTimer = 0;

    [Tooltip("Counts up until it reaches the current wave's max rest duration")]
    [SerializeField, ReadOnly] private float _restTimer = 0;
    
    [Tooltip("Counts up until it reaches the current wave's max time between spawns")]
    [SerializeField, ReadOnly] private float _spawnTimer = 0;

    [Tooltip("Counts up until it reaches the max index of the current wave's pattern list")]
    [SerializeField, ReadOnly] private int _patternIndex = 0;

    [Tooltip("Counts up until it reaches the max index of the wave list")]
    [SerializeField, ReadOnly] private int _waveIndex = 0;
    #endregion

    #region Spawn Data
    [Header("Spawn Data")]
    [Tooltip("The base prefab to spawn")]
    [SerializeField] private GameObject _spawnPrefab;

    [Tooltip("Acceptable locations to spawn the prefab")]
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    
    [Tooltip("Collection of game objects that have been spawned (used for deleting all objects in cleanup)")]
    [SerializeField, HideCustomDrawer] private GameObjectCollection _spawnedObjects;

    [SerializeField, HideCustomDrawer] private AnimationCurveVariable _spawnFluctuation;

    [Tooltip("The shortest allowable time between enemy spawns")]
    [SerializeField] private float _minimumSpawnTimeBuffer;

    private GameObject _previousSpawnPoint;
    #endregion

    #region Events
    [Header("EVENTS")]
    [Tooltip("Signifies when a wave begins")]
    [SerializeField] private GameEvent _waveEvent;

    [Tooltip("Signifies when a rest begins")]
    [SerializeField] private GameEvent _restEvent;

    [Tooltip("Signifies when combat ends")]
    [SerializeField] private GameEvent _endEvent;
    #endregion
    #endregion

    #region Methods
    void Awake()
    {
        _waveIndex = 0;
        _patternIndex = 0;
    }

    void Update()
    {

        // if all waves are done
        if (_waveIndex > _waves.Count - 1)
        {
            // --- set spawn state to STOP,
            _state = SpawnState.STOP;

            // --- end combat sequence
            _waveIndex = 0;
            _endEvent.Raise();
        }

        // get current wave with waveIndex
        WaveData currentWave = _waves[_waveIndex];

        switch(_state) 
        {
            case SpawnState.STOP:
                break;

            case SpawnState.WAVE:

                // increment wave timer
                _waveTimer += Time.deltaTime;

                // increment spawn timer
                _spawnTimer += Time.deltaTime;

                // TODO: refactor this to use enemy speed instead of spawn rate
                // get our current point in the spawn fluctuation
                // float timeBetweenSpawnsModifier = _spawnFluctuation.Value.Evaluate(_waveTimer / currentWave.Duration) * (_waveIndex + 1 / _waves.Count) * _spawnIntensity.Value;
                // float timeBetweenSpawns = currentWave.MaxTimeBetweenSpawns / timeBetweenSpawnsModifier;
                // timeBetweenSpawns = Mathf.Clamp(timeBetweenSpawns, _minimumSpawnTimeBuffer, currentWave.MaxTimeBetweenSpawns);

                // get count of enemies on screen
                GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                int numberOfEnemies = activeEnemies.Length;

                // only spawn enemies when none are active
                if (numberOfEnemies <= 0)
                {
                    // --- get current pattern with patternIndex
                    EnemyPattern currentPattern = currentWave.EnemyPatterns[Random.Range(0, currentWave.EnemyPatterns.Count)];
                    
                    // --- spawn enemies in a specific pattern
                    SpawnEnemyPattern(currentPattern);
                    
                    // --- reset spawn timer
                    _spawnTimer = 0;
                    
                    // --- increment patternIndex
                    _patternIndex += 1;
                    _patternIndex = Mathf.Clamp(_patternIndex, 0, currentWave.EnemyPatterns.Count - 1);

                }

                
                // if wave has ended
                if (_waveTimer >= currentWave.Duration)
                {
                    // --- reset timers
                    _waveTimer = 0;
                    _spawnTimer = 0;

                    // --- reset pattern index
                    _patternIndex = 0; 
                    
                    // --- set spawn state to REST
                    _state = SpawnState.REST;
                    _restEvent?.Raise();
                }

                break;

            case SpawnState.REST:
                // increment rest timer
                _restTimer += Time.deltaTime;

                // if the rest period is over
                if (_restTimer >= currentWave.RestPeriod)
                {
                    // --- reset rest timer
                    _restTimer = 0;

                    // --- increment wave index
                    _waveIndex += 1;

                    // --- switch state to WAVE
                    _state = SpawnState.WAVE;
                    _waveEvent?.Raise();
                }

                break;

            default:
                break;
        }
    }

    void SpawnEnemyPattern(EnemyPattern pattern)
    {
        if (_state != SpawnState.WAVE)
        {
            return;
        }

        GameObject spawnPoint;
        
        do
        {
            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        } 
        while (GameObject.ReferenceEquals(spawnPoint, _previousSpawnPoint));

        _previousSpawnPoint = spawnPoint;

        Transform spawnPointTransform = spawnPoint.GetComponent<Transform>();
        float offsetAmount = 1f;
        float enemyCount = 0;

        foreach(EnemyAttributes enemyType in pattern.Enemies)
        {
            // get spawn point data
            SpawnData spawnPointData = spawnPoint.GetComponent<SpawnData>();

            // spawn enemies in the pattern separated by an offset
            float xOffset = spawnPointData.XDirection * offsetAmount * enemyCount;
            float yOffset = spawnPointData.YDirection * offsetAmount * enemyCount;
            Vector3 spawnPosition = spawnPointTransform.position;
            Vector3 spawnPositionWithOffSet = new Vector3(spawnPosition.x - xOffset, spawnPosition.y - yOffset, spawnPosition.z); 
            GameObject spawnedObject = Instantiate(_spawnPrefab, spawnPositionWithOffSet, Quaternion.identity);

            // set the enemy's movement direction based on spawn point data
            if (spawnPointData != null)
            {
                spawnedObject.GetComponent<Enemy>().SetAttributes(enemyType);
                spawnedObject.GetComponent<MoveInOwnDirection>()?.SetDirection(new Vector2(spawnPointData.XDirection, spawnPointData.YDirection));
            }

            // track spawned object in a list
            if (!_spawnedObjects.Contains(spawnedObject))
            {
                _spawnedObjects.Add(spawnedObject);
            }

            // increment multiplier for the position offset
            enemyCount += 1;
        }

    }
    #endregion
}
