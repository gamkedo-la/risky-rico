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
    [SerializeField] private List<string> _disabledComponents = new List<string>();

    void Awake()
    {
        bool spawnFlag = ServiceLocator.Instance.Get<SaveDataManager>().GetFlag(_spawnFlag);
        if (spawnFlag == _flagValueToCheck || !_useFlags)
        {
            GameObject spawnedObject = Instantiate(_prefab, _spawnPoint.transform.position, Quaternion.identity);
            spawnedObject.SetActive(true);
            foreach (string componentName in _disabledComponents)
            {
                Component component = spawnedObject.GetComponent(System.Type.GetType(componentName));
                if (component != null)
                {
                    MonoBehaviour monoBehaviourComponent = (MonoBehaviour)component;
                    monoBehaviourComponent.enabled = false;
                }
                else
                {
                    Debug.LogWarning("Component " + componentName + "not found");
                }
            }
        }


    }
}
