using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
   [SerializeField] public EnemyAttributes enemy;
   private float _rotationTimer;

   void Update()
   {
        _rotationTimer += enemy.RotationFrequency * Time.deltaTime;

        if (enemy.RotationFrequency > 0f &&  _rotationTimer >= 1f)
        {
            // rotate the enemy gameobject
            transform.Rotate(0,0,90);

            // reset the timer
            _rotationTimer = 0f;
        }
   }
}
