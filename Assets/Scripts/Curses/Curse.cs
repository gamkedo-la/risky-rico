using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Curse : MonoBehaviour, IInteractable
{
    [SerializeField] private CurseData _curseData;
    public CurseData Parameters => _curseData;
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
        SetAttributes(_curseData);
    }

    public void SetAttributes(CurseData parameters)
    {
        _curseData = parameters;
        _renderer.sprite = _curseData.Image;
    }

    public void ActivateEffects(PlayerCurseSlots curseSlots)
    {
        if (curseSlots != null)
        {
            curseSlots.AddCurse(_curseData);
        }
    }

    public void ReceiveInteraction(GameObject interactor)
    {
        PlayerCurseSlots curseSlots = interactor.GetComponent<PlayerCurseSlots>();
        ActivateEffects(curseSlots);
        Destroy(gameObject);
    }
}
