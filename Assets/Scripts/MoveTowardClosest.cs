using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MoveTowardClosest : MonoBehaviour
{
    [SerializeField] private GameObjectCollection _targetObjects;
    [SerializeField] private float _movementRate = 1f;
    private GameObject targetObject;

    void Update()
    {
        float minDistance = Mathf.Infinity;
        Vector2 selfPosition = transform.position;

        foreach (GameObject obj in _targetObjects)
        {
            Vector2 targetPosition = obj.transform.position;
            float distance = (targetPosition - selfPosition).sqrMagnitude;

            if (distance < minDistance)
            {
                minDistance = distance;
                targetObject = obj;
            }
        }

        if (targetObject != null)
        {
            MoveTowardObject(targetObject);
        }
    }

   void MoveTowardObject(GameObject target)
   {
        transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime * _movementRate);
   }
}
