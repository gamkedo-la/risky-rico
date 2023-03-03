using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MoveInOwnDirection : MonoBehaviour
{
    [SerializeField]
    private float _xDirection = 0f;
    
    [SerializeField]
    private float _yDirection = 0f;

    [SerializeField]
    private FloatVariable _speed;

    void Update()
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        float nextX = currentX + _xDirection * _speed.Value * Time.deltaTime;
        float nextY = currentY + _yDirection * _speed.Value * Time.deltaTime;

        transform.position = new Vector3(nextX, nextY, transform.position.z);
    }

    public void SetDirection(Vector2 direction)
    {
        _xDirection = direction.x;
        _yDirection = direction.y;
    }

    public void FlipDirection()
    {
        _xDirection *= -1;
        _yDirection *= -1;
    }
}
