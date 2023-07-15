using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private GameObjectCollection _focusableObjects;
    [SerializeField] private GameObject _focalPoint;
    [SerializeField] private float _trackingSpeed = 0.02f;
    [SerializeField] private float _offsetX = 0f;
    [SerializeField] private float _offsetY = 0f;

    void Start()
    {
        if (_focalPoint == null && _focusableObjects.Count > 0)
        {
            _focalPoint = _focusableObjects[0];
        }

        if (_focalPoint != null)
        {
            SetPositionToFocalPoint();
        }
    }

    void LateUpdate()
    {
        SetPositionToFocalPoint();
    }

    void SetPositionToFocalPoint()
    {
        if (_focalPoint == null) return;
        Vector3 focalPointPosition = new Vector3(_focalPoint.transform.position.x + _offsetX, _focalPoint.transform.position.y + _offsetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, focalPointPosition, _trackingSpeed);
    }
}
