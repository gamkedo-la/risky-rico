using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private string _spawnFlag;
    [SerializeField] private bool _useFlags;

    void Awake()
    {
        bool spawnFlag = ServiceLocator.Instance.Get<SaveDataManager>().GetFlag(_spawnFlag);
        if (spawnFlag || !_useFlags)
        {
            Instantiate(_playerPrefab, _spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
