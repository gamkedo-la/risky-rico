using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Vector2Variable _aimDirection;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private SoundEffect _sound;
    [SerializeField] private GameEvent _shootEvent;
    [SerializeField] private PlayerAttributes _player;
    private float _shotTimer;

    void Awake()
    {
        _shotTimer = 1f;
    }

    void Update()
    {
        // tick shot timer upward by the player's firing rate
        _shotTimer += Time.deltaTime * _player.FiringRate.CurrentValue;

        // update aiming direction with inputs and shoot when the timer reaches 1
        if (_input.actions["shoot"].triggered && _shotTimer >= 1f)
        {
            float offsetAmount = 1f;
            float _aimDirectionX = _input.actions["shoot"].ReadValue<Vector2>().x;
            float _aimDirectionY = _input.actions["shoot"].ReadValue<Vector2>().y;
            _aimDirection.Value = new Vector2(_aimDirectionX, _aimDirectionY);

            for (float i = 0; i < _player.ShotCount.CurrentValue; i++)
            {
                float offsetX = _aimDirectionX * offsetAmount * i;
                float offsetY = _aimDirectionY * offsetAmount * i;
                SpawnProjectile(offsetX, offsetY);
            }
            
            _shootEvent.Raise();
            _sound.Play();
            _shotTimer = 0f;
        }
    }

    void SpawnProjectile(float bufferX, float bufferY)
    {
        // set spawn position
        Vector3 spawnPosition = new Vector3(transform.position.x + bufferX, transform.position.y + bufferY, transform.position.z);
        
        // spawn object
        GameObject _newProjectile = Instantiate(_projectile, spawnPosition, Quaternion.identity);

        // set rotation
        float angle = Mathf.Atan2(_aimDirection.Value.y, _aimDirection.Value.x) * Mathf.Rad2Deg - 90f;
        _newProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // move the new object in the aiming direction
        MoveInOwnDirection moveComponent = _newProjectile.GetComponent<MoveInOwnDirection>();
        if (moveComponent != null)
        {
            _newProjectile.GetComponent<MoveInOwnDirection>().SetDirection(_aimDirection.Value);
        }

        // set damage of the projectile
        DamageController damageController = _newProjectile.GetComponent<DamageController>();
        if (damageController != null)
        {
            damageController.SetDamage(_player.Damage.CurrentValue);
        }
    }
}
