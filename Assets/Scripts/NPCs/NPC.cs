using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ScriptableObjectArchitecture;

public class NPC : MonoBehaviour, IInteractable
{
    [Header("DIALOG")]
    [SerializeField, HideCustomDrawer] private DialogSequence _activeDialogueSequence;
    [SerializeField] private DialogSequence _npcDialogueSequence;
    
    [Header("EVENTS")]
    [SerializeField] private GameEvent _onDialogStart;
    [SerializeField] private UnityEvent _onDialogEnd;
    
    [Header("INTERACTIONS")]
    [SerializeField] private string _interactionPrompt;

    public string Prompt {get; set; }
    public bool InteractionEnabled {get; set; }

    void Start()
    {
        Prompt = _interactionPrompt;
        InteractionEnabled = true;
    }

    public void ReceiveInteraction(GameObject interactor)
    {
       if (_npcDialogueSequence != null && _activeDialogueSequence != null)
       {
            _activeDialogueSequence.SetLines(_npcDialogueSequence.Lines);

            InteractionEnabled = false;
            
            _onDialogStart?.Raise();
       }
    }
}
