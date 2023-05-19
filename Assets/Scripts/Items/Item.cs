using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemParameters _parameters;
    [SerializeField] private SpriteRenderer _renderer;

    public string Prompt {get; set; }
    public bool InteractionEnabled {get; set; }

    void Awake()
    {
        InteractionEnabled = true;
        Prompt = "Pick up";

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

    public void ReceiveInteraction(GameObject interactor)
    {
        Debug.Log("Item found");
        InteractionEnabled = false;
        Destroy(gameObject);
    }
}
