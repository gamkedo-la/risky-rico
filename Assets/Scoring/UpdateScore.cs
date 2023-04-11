using UnityEngine;
using ScriptableObjectArchitecture;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private FloatVariable _score;

    void Awake()
    {
        _score.Value = 0f;
    }

    public void IncreaseScore()
    {
        _score.Value += 10;
    }
}
