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

    void Start()
    {
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
        Debug.Log(collision.gameObject);

        if (!_damagingObjects.Contains(collision.gameObject))
        {
            Debug.Log("not a damaging object");
            return;
        }  

        // assume zero damage as default
        int xDamage = 0;
        int yDamage = 0;

        // get point of contact and collider boundaries
        Vector3 contactPoint = collision.contacts[0].point;
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        Bounds otherBounds = collision.gameObject.GetComponent<BoxCollider2D>().bounds;
        Vector3 center = bounds.center;
        Vector3 otherCenter = otherBounds.center;

        // contained within height boundary of other collider
        if (otherCenter.y > center.y - bounds.extents.y && otherCenter.y < center.y + bounds.extents.y)
        {
            Debug.Log("Contact x");
            xDamage = 1;
        }

        // contained within height boundary of other collider
        if (otherCenter.x > center.x - bounds.extents.x && otherCenter.x < center.x + bounds.extents.x)
        {
            Debug.Log("Contact y");
            yDamage = 1;
        }

        // apply damage
        TakeDamage(xDamage, yDamage);

        Destroy(collision.gameObject);
    }

    void Update()
    {
        if (_yHealth <= 0 || _xHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
