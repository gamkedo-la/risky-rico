using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MoveWithCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurveVariable _movementCurve;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, _movementCurve.Value.Evaluate((Time.time % _movementCurve.Value.length)), transform.position.z);
    }
}
