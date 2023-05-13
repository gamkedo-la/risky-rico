using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Curse : MonoBehaviour
{
    [SerializeField] private CurseData _parameters;
    public CurseData Parameters => _parameters;
    [SerializeField] private SpriteRenderer _renderer;

    void Awake()
    {
        // get necesssary components
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        // apply parameters to individual components
        SetAttributes(_parameters);
    }

    public void SetAttributes(CurseData parameters)
    {
        _parameters = parameters;
        _renderer.sprite = _parameters.Image;
    }

    public void ActivateEffects(PlayerAttributes playerParameters)
    {
        Debug.Log("Activating effects of " + _parameters.name);
    }
}
