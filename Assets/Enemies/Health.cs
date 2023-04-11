using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Health : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _xHealth;
    [SerializeField] private int _yHealth;
    public int YHealth => _yHealth;
    public int XHealth => _xHealth;
    public int XHealthMax { get; private set; }
    public int YHealthMax { get; private set; }

    [Header("Collisions")]
    [SerializeField] private GameObjectCollection _damagingObjects;
    private BoxCollider2D _collider;

    [Header("Events")]
    [SerializeField] private List<GameEventBase> _damageEvents = new List<GameEventBase>();
    [SerializeField] private List<GameEventBase> _deathEvents = new List<GameEventBase>();

    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        XHealthMax = _xHealth;
        YHealthMax = _yHealth;
    }

    public void TakeDamage(int xDamage, int yDamage)
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
        int xDamage = 0;
        int yDamage = 0;

        // get center points and collider boundaries
        Bounds bounds = _collider.bounds;
        Bounds otherBounds = collision.gameObject.GetComponent<BoxCollider2D>().bounds;
        Vector3 center = bounds.center;
        Vector3 otherCenter = otherBounds.center;

        // contained within height boundary of other collider
        if (otherCenter.y > center.y - bounds.extents.y && otherCenter.y < center.y + bounds.extents.y)
        {
            xDamage = 1;
        }

        // contained within width boundary of other collider
        if (otherCenter.x > center.x - bounds.extents.x && otherCenter.x < center.x + bounds.extents.x)
        {
            yDamage = 1;
        }

        // apply damage based on x and y values
        TakeDamage(xDamage, yDamage);
        foreach(GameEventBase e in _damageEvents)
        {
            e.Raise();
        }

        // remove colliding object from scene
        Destroy(collision.gameObject);
    }

    void Update()
    {
        if (_yHealth <= 0 || _xHealth <= 0)
        {
            foreach(GameEventBase e in _deathEvents)
            {
                e.Raise();
            }

            Destroy(gameObject);
        }
    }
}
