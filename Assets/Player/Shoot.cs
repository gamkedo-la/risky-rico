using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    [SerializeField] private Vector2Variable _aimDirection;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private PlayerInput _input;
    private float _shotDelay = 1f;
    private float _shotSpeed = 3f;
    private float _timeBetweenShots;
    private bool _didShoot = false; 

    void Awake() 
    {
        _timeBetweenShots = _shotDelay;
    }

    void Update()
    {
        if (_input.actions["shoot"].triggered && !_didShoot)
        {
            SpawnProjectile();
            _didShoot = true;
        }

        if (_didShoot)
        {
            _timeBetweenShots -= Time.deltaTime;
        }

        if (_timeBetweenShots <= 0)
        {
            _didShoot = false;
            _timeBetweenShots = _shotDelay;
        }
    }

    void SpawnProjectile()
    {
        GameObject _newProjectile = Instantiate(_projectile, transform.position, Quaternion.identity);
        _newProjectile.GetComponent<MoveInOwnDirection>().SetDirection(_aimDirection.Value * _shotSpeed);
    }
}
