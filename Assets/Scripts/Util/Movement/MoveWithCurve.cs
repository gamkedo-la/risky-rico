using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MoveWithCurve : MonoBehaviour
{
    private float _baseY;
    [SerializeField] private float _amplitude = 1f;
    [SerializeField] private float _frequency = 1f;

    void Awake()
    {
        _baseY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, _baseY + Mathf.Sin(Time.time * _frequency) * _amplitude, transform.position.z);
    }
}
