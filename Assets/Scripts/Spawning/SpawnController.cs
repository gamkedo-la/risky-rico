using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public enum SpawnState 
{
    WAVE,
    REST
}
public class SpawnController : MonoBehaviour
{
    [Header("Collections")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<EnemyParameters> _spawnTypes;
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private GameObjectCollection _spawnedObjects;
    private List<EnemyParameters> _targetSpawnTypes = new List<EnemyParameters>();
    private List<GameObject> _targetSpawnPoints = new List<GameObject>();
    [SerializeField] private bool addSelfToList = false;

    [Header("Tempo")]
    [SerializeField] private FloatVariable _timeBetweenSpawns;
    [SerializeField] private FloatReference _defaultTimeBetweenSpawns;

    [Header("Waves")]
    [SerializeField] private FloatVariable _waveDuration;
    [SerializeField] private FloatReference _defaultWaveDuration;
    [SerializeField] private IntEnemyParametersDictionary _waveMap;
    private int _waveCount = 1;

    [Header("Rest")]
    [SerializeField] private FloatVariable _restDuration;
    [SerializeField] private FloatReference _defaultRestDuration;
    [SerializeField] private SpawnState _state = SpawnState.WAVE;

    [Header("Events")]
    [SerializeField] private GameEvent _waveEvent;
    [SerializeField] private GameEvent _restEvent;

    void Awake()
    {
        _waveDuration.Value = _defaultWaveDuration.Value;
        _restDuration.Value = _defaultRestDuration.Value;
        _timeBetweenSpawns.Value = _defaultTimeBetweenSpawns.Value;

        if (addSelfToList)
        {
            _spawnedObjects.Add(gameObject);
        }
    }

    void Update()
    {
        // update state
        if (_state == SpawnState.WAVE)
        {
            _waveDuration.Value -= 1 * Time.deltaTime;
            _timeBetweenSpawns.Value -= 1 * Time.deltaTime;

            // spawn when timer hits 0
            if (_timeBetweenSpawns.Value <= 0f && _waveDuration.Value > 0f)
            {
                PickSpawnType();
                PickSpawnPoint();
                SpawnObjects();
                _timeBetweenSpawns.Value = _defaultTimeBetweenSpawns.Value * (_waveDuration.Value / _defaultWaveDuration.Value);
                _timeBetweenSpawns.Value = Mathf.Clamp(_timeBetweenSpawns.Value, 0.5f, _defaultTimeBetweenSpawns.Value);
            }
        }

        if (_state == SpawnState.REST)
        {
            _restDuration.Value -= 1 * Time.deltaTime;
        }

        // change state 
        if (_waveDuration.Value <= 0f && _spawnedObjects.Count == 0)
        {
            _state = SpawnState.REST;
            _waveDuration.Value = _defaultWaveDuration.Value;
            _waveCount += 1;
            _restEvent?.Raise();
            UpdateAvailableSpawnTypes();
        }

        if (_restDuration.Value <= 0f)
        {
            _state = SpawnState.WAVE;
            _restDuration.Value = _defaultRestDuration.Value;
            _waveEvent?.Raise();
        }
    }

    public void UpdateAvailableSpawnTypes()
    {
        foreach(int i in _waveMap.Keys)
        {
            if (_waveCount >= i && !_spawnTypes.Contains(_waveMap[i]))
            {
                _spawnTypes.Add(_waveMap[i]);
            }
        }
    }

    public void PickSpawnType()
    {
        int index = Random.Range(0, _spawnTypes.Count);
        EnemyParameters spawnType = _spawnTypes[index];
        _targetSpawnTypes.Add(spawnType);
    }

    public void PickSpawnPoint()
    {
        int index = Random.Range(0, _spawnPoints.Count);
        GameObject spawnPoint = _spawnPoints[index];
        _targetSpawnPoints.Add(spawnPoint);
    }
    
    public void SpawnObjects() 
    {
        foreach(GameObject spawnPoint in _targetSpawnPoints)
        {
            foreach(EnemyParameters enemyType in _targetSpawnTypes)
            {
                // get spawn point information
                Transform spawnPointTransform = spawnPoint.GetComponent<Transform>();
                SpawnData spawnPointData = spawnPoint.GetComponent<SpawnData>();

                // set spawned game object properties
                GameObject spawnedObject = Instantiate(_enemyPrefab, spawnPointTransform.position, Quaternion.identity);
                if (spawnPointData != null)
                {
                    spawnedObject.GetComponent<Enemy>().SetParameters(enemyType);
                    spawnedObject.GetComponent<MoveInOwnDirection>()?.SetDirection(new Vector2(spawnPointData.XDirection, spawnPointData.YDirection));
                }

                // track spawned object in a list
                if (!_spawnedObjects.Contains(spawnedObject))
                {
                    _spawnedObjects.Add(spawnedObject);
                }
            }
        }
        
        _targetSpawnPoints.Clear();
        _targetSpawnTypes.Clear();
    }

    public void DestroyObjects() 
    {
        foreach(GameObject obj in _spawnedObjects)
        {
            Destroy(obj);
        }
    }
}
