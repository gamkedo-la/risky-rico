using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;

public class InteractionRadius : MonoBehaviour
{
    private PlayerInput _input;
    public List<IInteractable> interactables = new List<IInteractable>();
    public float detectionDistance = 2f;

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
                interactables.Add(interactable);
            }
        }

        // interact with the nearest interactable on input
        if (_input.actions["interact"].triggered && interactables.Count > 0)
        {
            interactables[0].ReceiveInteraction(gameObject);
        }
    }
}
