using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateControllerParameterProvider : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] bool _inMenu;

    void Awake()
    {
        _animator.SetBool("InMenu", _inMenu);
    }
}
