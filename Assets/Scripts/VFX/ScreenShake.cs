using UnityEngine;
using ScriptableObjectArchitecture;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] private float _maxScreenShakeOffset; // maximum offset for shaking translationally
    [SerializeField] private FloatVariable _traumaLevel; // determines time and power of screenshake
    [SerializeField] private FloatVariable _maxTraumaLevel; // determines maximum screenshake multiplier
    [SerializeField] private bool _shakeX;
    [SerializeField] private bool _shakeY;
    [SerializeField] private bool _rotate;
    [SerializeField] private Vector2 _initialPosition;

    void Start()
    {
        _initialPosition.x = gameObject.transform.localPosition.x;
        _initialPosition.y = gameObject.transform.localPosition.y;
    }

    void Update()
    {
        // decrease trauma over time
        _traumaLevel.Value = (_traumaLevel.Value - Time.deltaTime) * _maxTraumaLevel.Value;
        if (_traumaLevel <= 0)
        {
            gameObject.transform.localPosition = new Vector3(_initialPosition.x, _initialPosition.y, gameObject.transform.localPosition.z);
        }

        // get trauma level of current shake
        float shake = Mathf.Pow(_traumaLevel.Value, 2);
        float offsetY = _shakeY ? shake * _maxScreenShakeOffset * Random.Range(-1, 1) : 0f;
        float offsetX = _shakeX ? shake * _maxScreenShakeOffset * Random.Range(-1, 1) : 0f;

        // move camera
        float newX = _initialPosition.x + offsetX;
        float newY = _initialPosition.y + offsetY;
        gameObject.transform.localPosition = new Vector3(newX, newY, gameObject.transform.localPosition.z);

    }
}
