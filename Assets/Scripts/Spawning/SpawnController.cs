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
    [SerializeField] private List<GameObject> _spawnTypes;
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    private List<GameObject> _spawnedObjects = new List<GameObject>();
    private List<GameObject> _targetSpawnTypes = new List<GameObject>();
    private List<GameObject> _targetSpawnPoints = new List<GameObject>();
    [SerializeField] private bool addSelfToList = false;

    [Header("Tempo")]
    [SerializeField] private FloatVariable _timeBetweenSpawns;
    [SerializeField] private FloatReference _defaultTimeBetweenSpawns;

    [Header("Waves")]
    [SerializeField] private FloatVariable _waveDuration;
    [SerializeField] private FloatReference _defaultWaveDuration;
    [SerializeField] private IntGameObjectDictionary _waveMap;
    private int _waveCount = 1;

    [Header("Rest")]
    [SerializeField] private FloatVariable _restDuration;
    [SerializeField] private FloatReference _defaultRestDuration;
    [SerializeField] private SpawnState _state = SpawnState.WAVE;

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
            if (_timeBetweenSpawns.Value <= 0f)
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
        if (_waveDuration.Value <= 0f)
        {
            _state = SpawnState.REST;
            _waveDuration.Value = _defaultWaveDuration.Value;
            _waveCount += 1;
            UpdateAvailableSpawnTypes();
        }

        if (_restDuration.Value <= 0f)
        {
            _state = SpawnState.WAVE;
            _restDuration.Value = _defaultRestDuration.Value;
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
        GameObject spawnType = _spawnTypes[index];
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
            foreach(GameObject obj in _targetSpawnTypes)
            {
                // get spawn point information
                Transform spawnPointTransform = spawnPoint.GetComponent<Transform>();
                SpawnData spawnPointData = spawnPoint.GetComponent<SpawnData>();

                // set spawned game object properties
                GameObject spawnedObject = Instantiate(obj, spawnPointTransform.position, Quaternion.identity);
                if (spawnPointData != null)
                {
                    spawnedObject.GetComponent<MoveInOwnDirection>()?.SetDirection(new Vector2(spawnPointData.XDirection, spawnPointData.YDirection));
                }

                // track spawned object in a list
                _spawnedObjects.Add(spawnedObject);
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