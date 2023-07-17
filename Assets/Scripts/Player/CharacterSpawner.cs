using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private string _spawnFlag;
    [SerializeField] private bool _useFlags;
    [SerializeField] private bool _flagValueToCheck;

    void Awake()
    {
        bool spawnFlag = ServiceLocator.Instance.Get<SaveDataManager>().GetFlag(_spawnFlag);
        if (spawnFlag == _flagValueToCheck || !_useFlags)
        {
            GameObject spawnedObject = Instantiate(_prefab, _spawnPoint.transform.position, Quaternion.identity);
            spawnedObject.SetActive(true);
        }
    }
}
