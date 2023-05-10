using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;


public class PickUpItem : MonoBehaviour
{
    [SerializeField] GameObjectCollection _itemCollection;
    [SerializeField] PlayerParameters _playerParameters;
    [SerializeField] GameObject _particleEffect;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (_itemCollection.Contains(collision.gameObject))
        {
            // Get item and activate its effect
            Item itemComponent = collision.gameObject.GetComponent<Item>();
            if (itemComponent != null)
            {
                itemComponent.ActivateEffects(_playerParameters);
            }

            // Spawn particle effect
            Instantiate(_particleEffect, transform.position, Quaternion.identity);

            // Remove item from scene
            Destroy(collision.gameObject);
        }
    }
}
