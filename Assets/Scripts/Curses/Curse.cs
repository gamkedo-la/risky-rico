using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Curse : MonoBehaviour
{
    [SerializeField] private CurseParameters _parameters;
    public CurseParameters Parameters => _parameters;
    [SerializeField] private SpriteRenderer _renderer;

    void Awake()
    {
        // get necesssary components
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        // apply parameters to individual components
        SetParameters(_parameters);
    }

    public void SetParameters(CurseParameters parameters)
    {
        _parameters = parameters;
        _renderer.sprite = _parameters.Image;
    }

    public void ActivateEffects(PlayerParameters playerParameters)
    {
        Debug.Log("Activating effects of " + _parameters.name);
    }
}