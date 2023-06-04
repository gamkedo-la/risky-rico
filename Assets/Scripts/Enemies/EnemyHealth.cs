using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float _xHealth;
    [SerializeField] private float _yHealth;
    public float YHealth => _yHealth;
    public float XHealth => _xHealth;
    public float XHealthMax { get; private set; }
    public float YHealthMax { get; private set; }

    [Header("Collisions")]
    [SerializeField] private GameObjectCollection _damagingObjects;
    public GameObjectCollection DamagingObjects => _damagingObjects;
    private BoxCollider2D _collider;

    [Header("Events")]
    [SerializeField] private UnityEvent _damageEvents = new UnityEvent();
    [SerializeField] private UnityEvent _deathEvents = new UnityEvent();

    [Header("Visual Effects")]
    [SerializeField] private GameObject _explosion;
    [SerializeField] private GameObject _damageSplash;

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        XHealthMax = _xHealth;
        YHealthMax = _yHealth;
    }

    public void SetHealth(float xHealth, float yHealth)
    {
        _xHealth = xHealth;
        _yHealth = yHealth;
    }

    public void TakeDamage(float xDamage, float yDamage)
    {
        _xHealth -= xDamage;
        _yHealth -= yDamage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_damagingObjects.Contains(collision.gameObject))
        {
            Debug.Log("not a damaging object");
            return;
        }  

        // assume zero damage as default
        float xDamage = 0;
        float yDamage = 0;

        // get center points and collider boundaries
        Bounds bounds = _collider.bounds;
        Bounds otherBounds = collision.gameObject.GetComponent<BoxCollider2D>().bounds;
        Vector3 center = bounds.center;
        Vector3 otherCenter = otherBounds.center;

        // get damage data of colliding object
        DamageController damageController = collision.gameObject.GetComponent<DamageController>();
        float defaultDamageAmount = 1;
        if (damageController != null)
        {
            defaultDamageAmount = damageController.Damage;
        }

        // check if colliding object is contained within height boundary of this collider
        if (otherCenter.y > center.y - bounds.extents.y && otherCenter.y < center.y + bounds.extents.y)
        {
            xDamage = defaultDamageAmount;
        }

        // check if colliding object is contained within width boundary of this collider
        if (otherCenter.x > center.x - bounds.extents.x && otherCenter.x < center.x + bounds.extents.x)
        {
            yDamage = defaultDamageAmount;
        }

        // apply damage based on x and y values
        TakeDamage(xDamage, yDamage);

        // invoke follow-up damage events
        _damageEvents?.Invoke();

        // spawn particle effects
        Instantiate(_damageSplash, transform.position, transform.rotation);

        // get ammo data of the projectile
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        // get type of ammo
        if (bullet != null)
        {
            // based on ammo type, affect the enemy gameobject
            bullet.ApplyAmmoEffect(gameObject);
        }

        // remove colliding object from scene
        if (bullet.CanBeDestoyedByEnemies)
        {
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (_yHealth <= 0 || _xHealth <= 0)
        {
            _deathEvents?.Invoke();
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
