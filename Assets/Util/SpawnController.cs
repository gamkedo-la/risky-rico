using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _spawnTypes;
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    private List<GameObject> _spawnedObjects = new List<GameObject>();
    private List<GameObject> _targetSpawnTypes = new List<GameObject>();
    private List<GameObject> _targetSpawnPoints = new List<GameObject>();

    [SerializeField]
    private bool addSelfToList = false;

    void Awake()
    {
        if (addSelfToList)
        {
            _spawnedObjects.Add(gameObject);
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
