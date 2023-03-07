using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    [SerializeField] private Vector2Variable _aimDirection;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private PlayerInput _input;
    private float _shotSpeed = 3f;

    void Update()
    {
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
        Vector3 spawnPosition = new Vector3(transform.position.x + _aimDirection.Value.x, transform.position.y + _aimDirection.Value.y, transform.position.z);
        GameObject _newProjectile = Instantiate(_projectile, spawnPosition, Quaternion.identity);
        _newProjectile.GetComponent<MoveInOwnDirection>().SetDirection(_aimDirection.Value * _shotSpeed);
    }
}
