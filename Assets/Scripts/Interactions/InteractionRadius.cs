using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using ScriptableObjectArchitecture;

public class InteractionRadius : MonoBehaviour
{
    [Header("INPUTS")]
    private PlayerInput _input;

    [Header("DETECTION SETTINGS")]
    public List<IInteractable> interactables = new List<IInteractable>();
    public float detectionDistance = 2f;

    [Header("UI")]
    [SerializeField] private StringReference _interactionPrompt;

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // keep a fresh list of interactables on every frame
        interactables.Clear();
        GameObject[] objects = FindObjectsOfType<GameObject>();

        // check if any interactables are within range and enabled
        foreach(GameObject otherObject in objects)
        {
            if(GameObject.ReferenceEquals(otherObject, gameObject))
            {
                continue;
            }

            IInteractable interactable = otherObject.GetComponent<IInteractable>();

            if  (
                    Vector3.Distance(transform.position, otherObject.transform.position) <= detectionDistance && 
                    interactable != null && 
                    interactable.InteractionEnabled
                )
            {
                // add interactable to a list of interactables that is treated as a stack (last in, first out)
                interactables.Add(interactable);

                // signal UI to display interation prompt
                _interactionPrompt.Value = interactable.Prompt;
            }
        }

        // reset UI when no interactable is near
        if (interactables.Count == 0)
        {
            _interactionPrompt.Value = "";
        }

        // interact with the last interactable (top of the stack)
        if (_input.actions["interact"].triggered && interactables.Count > 0)
        {
            interactables.Last().ReceiveInteraction(gameObject);
        }
    }
}
