using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateControllerParameterProvider : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _inMenu;

    void Update()
    {
        _animator.SetBool("InMenu", _inMenu);
    }

    public void SetMenuState(bool inMenu)
    {
        _inMenu = inMenu;
    }
}
