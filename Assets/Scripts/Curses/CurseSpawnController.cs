using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class CurseSpawnController : MonoBehaviour
{
    #region Inspector Info
    [Header("Collections")]
    [Tooltip("The prefab to spawn")]
    [SerializeField] private GameObject _prefab;

    [Tooltip("The types of objects that can spawn")]
    [SerializeField] private List<CurseParameters> _spawnTypes;

    [Tooltip("Acceptable locations to spawn")]
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    
    [Tooltip("A collection to track the spawned objects")]
    [SerializeField] private GameObjectCollection _spawnedObjectCollection;
    #endregion

    #region Methods

    public void SpawnAtAllPoints()
    {
        foreach(GameObject spawnPoint in _spawnPoints)
        {            
            // get spawn point information
            Transform spawnPointTransform = spawnPoint.GetComponent<Transform>();

            // type of object to spawn
            CurseParameters spawnType = PickSpawnType();

            // spawn the object
            GameObject spawnedObject = Instantiate(_prefab, spawnPointTransform.position, Quaternion.identity);

            // set parameters of new object
            Curse curseComponent = spawnedObject.GetComponent<Curse>();
            if (curseComponent != null)
            {
                curseComponent.SetParameters(spawnType);
            }
    
            // track spawned object in a list
            if (!_spawnedObjectCollection.Contains(spawnedObject))
            {
                _spawnedObjectCollection.Add(spawnedObject);
            }
        }
    }

    public CurseParameters PickSpawnType()
    {
        int index = Random.Range(0, _spawnTypes.Count);
        CurseParameters spawnType = _spawnTypes[index];
        return spawnType;
    }

    #endregion
}