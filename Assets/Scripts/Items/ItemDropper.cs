using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private ItemDropTable _dropTable;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField, Range(0.1f, 1f)] private float _dropChance;

    public void GetRandomItemFromTable()
    {
        float randomNumber = Random.Range(0, _dropTable.ProbabilityTotalWeight / _dropChance);

        List<ItemParameters> itemKeys = new List<ItemParameters>(_dropTable.Lookup.Keys);

        foreach(ItemParameters item in itemKeys)
        {
            if (randomNumber > _dropTable.Lookup[item].probabilityFrom && randomNumber < _dropTable.Lookup[item].probabilityTo)
            {
                Debug.Log("dropped: " + item.name);
                GameObject droppedItem = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
                droppedItem.GetComponent<Item>().SetParameters(item);
            }
        }
    }
}
