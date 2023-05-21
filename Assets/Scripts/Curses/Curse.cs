using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Curse : MonoBehaviour, IInteractable
{
    [SerializeField] private CurseData _parameters;
    public CurseData Parameters => _parameters;
    [SerializeField] private SpriteRenderer _renderer;

    public string Prompt {get; set; }
    public bool InteractionEnabled {get; set; }

    void Awake()
    {
        // set interaface members
        InteractionEnabled = true;
        Prompt = "E: Take the curse";

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

    public void ReceiveInteraction(GameObject interactor)
    {
         Destroy(gameObject);
    }
}
