using UnityEngine;
using ScriptableObjectArchitecture;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private FloatVariable _score;
    [SerializeField] private FloatVariable _scoreMultiplier;
    [SerializeField] private FloatVariable _maxScoreMultiplier;

    void Awake()
    {
        _score.Value = 0f;
        _scoreMultiplier.Value = 1f;
    }

    public void BreakCombo()
    {
        _scoreMultiplier.Value = 1f;
    }

    public void IncreaseScore(FloatVariable points)
    {
        // increase the score multiplier for consecutive kills; don't increase it past the max multiplier
        _score.Value += points.Value * _scoreMultiplier.Value;
        _scoreMultiplier.Value += 1f;
        _scoreMultiplier.Value = Mathf.Clamp(_scoreMultiplier.Value, 0f, _maxScoreMultiplier.Value);
    }
}
