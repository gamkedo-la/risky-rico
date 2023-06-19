using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, PlayerControls.IPlayerActions
{
    private PlayerControls _inputs;

    private void Awake()
    {
        _inputs = new PlayerControls();
        _inputs.Player.Shoot.performed += OnShoot;
        _inputs.Player.Move.performed += OnMove;
        _inputs.Player.SwitchWeapon.performed += OnSwitchWeapon;
        _inputs.Player.Interact.performed += OnInteract;
        _inputs.Player.Pause.performed += OnPause;
        _inputs.Player.Navigate.performed += OnNavigate;
        _inputs.Player.Exit.performed += OnExit;
    }

    // player
    public void OnShoot(InputAction.CallbackContext context) 
    {
        Debug.Log("OnShoot");
    }
    public void OnMove(InputAction.CallbackContext context) 
    {
        Debug.Log("OnMove");
    }
    public void OnSwitchWeapon(InputAction.CallbackContext context) 
    {
        Debug.Log("OnSwitchWeapon");

    }
    public void OnInteract(InputAction.CallbackContext context) 
    {
        Debug.Log("OnInteract");

    }
    public void OnPause(InputAction.CallbackContext context) 
    {
        Debug.Log("OnPause");

    }
    public void OnNavigate(InputAction.CallbackContext context) 
    {
        Debug.Log("OnNavigate");

    }
    public void OnExit(InputAction.CallbackContext context) 
    {
        Debug.Log("OnExit");
    }
}
