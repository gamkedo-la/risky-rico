using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
public class StorageChest : MonoBehaviour, IInteractable
{
    [SerializeField] private GameEvent _onOpenStorageMenu;

    [SerializeField] private string _interactionPrompt;
    public string Prompt { get; set; }
    public bool InteractionEnabled { get; set; }

    void Start()
    {
        Prompt = _interactionPrompt;
        InteractionEnabled = true;
    }

    public void ReceiveInteraction(GameObject interactor)
    {
        _onOpenStorageMenu?.Raise();
        InteractionEnabled = false;
    }
}
