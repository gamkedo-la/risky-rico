using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemParameters _parameters;
    [SerializeField] private SpriteRenderer _renderer;

    void Awake()
    {
        // get necesssary components
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        // apply parameters to individual components
        SetAttributes(_parameters);
    }

    public void SetAttributes(ItemParameters parameters)
    {
        _parameters = parameters;
        _renderer.sprite = _parameters.Image;
    }

    public void ActivateEffects(PlayerAttributes playerParameters)
    {
        Debug.Log("Activating effects of " + _parameters.name);
    }
}
