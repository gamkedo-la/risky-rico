using UnityEngine;
using ScriptableObjectArchitecture;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private FloatVariable _score;

    void Awake()
    {
        _score.Value = 0f;
    }

    void Update()
    {
        _score.Value += 1 * Time.deltaTime;
    }
}
