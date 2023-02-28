using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInOwnDirection : MonoBehaviour
{
    [SerializeField]
    private float _xDirection = 0f;
    
    [SerializeField]
    private float _yDirection = 0f;

    void Update()
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        float nextX = currentX + _xDirection * Time.deltaTime;
        float nextY = currentY + _yDirection * Time.deltaTime;

        transform.position = new Vector3(nextX, nextY, transform.position.z);
    }

    public void SetDirection(Vector2 direction)
    {
        _xDirection = direction.x;
        _yDirection = direction.y;
    }
}
