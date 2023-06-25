using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private IntVariable ammoCount;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Sprite[] sprites;

    void Update()
    {
        if (sprites[ammoCount.Value] != null)
        {
            _spriteRenderer.sprite = sprites[ammoCount.Value];
        }
    }
}
