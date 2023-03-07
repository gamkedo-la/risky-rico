using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Vector2Variable _aimDirection;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private PlayerInput _input;

    void Update()
    {
        // update aiming direction with inputs and shoot
        if (_input.actions["shoot"].triggered)
        {
            float _aimDirectionX = _input.actions["shoot"].ReadValue<Vector2>().x;
            float _aimDirectionY = _input.actions["shoot"].ReadValue<Vector2>().y;
            _aimDirection.Value = new Vector2(_aimDirectionX, _aimDirectionY);
            SpawnProjectile();
        }
    }

    void SpawnProjectile()
    {
        // set spawn position
        float bufferX = _aimDirection.Value.x;
        float bufferY = _aimDirection.Value.y;
        Vector3 spawnPosition = new Vector3(transform.position.x + bufferX, transform.position.y + bufferY, transform.position.z);
        
        // spawn object
        GameObject _newProjectile = Instantiate(_projectile, spawnPosition, Quaternion.identity);

        // move the new object in the aiming direction
        MoveInOwnDirection moveComponent = _newProjectile.GetComponent<MoveInOwnDirection>();
        if (moveComponent != null)
        {
            _newProjectile.GetComponent<MoveInOwnDirection>().SetDirection(_aimDirection.Value);
        }
    }
}
