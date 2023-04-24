using UnityEngine;

public class ResizeEnemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private SpriteRenderer _renderer;

    void Update()
    {
        float width = (float) _health.XHealth / (float) _health.XHealthMax;
        float height = (float) _health.YHealth / (float) _health.YHealthMax;

        _renderer.size = new Vector2(width, height);
        _collider.size = new Vector2(_renderer.size.x, _renderer.size.y);
    }
}
