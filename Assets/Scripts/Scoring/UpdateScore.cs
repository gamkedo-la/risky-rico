using UnityEngine;
using ScriptableObjectArchitecture;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private FloatVariable _score;
    [SerializeField] private FloatVariable _scoreMultiplier;
    [SerializeField] private FloatVariable _maxScoreMultiplier;
    [SerializeField] private FloatVariable _shakeAmount;
    [SerializeField] private GameObject _pointTextPrefab;
    [SerializeField] private SoundEffect _scoreSound;

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
        // spawn text object to show score increase
        GameObject pointText = Instantiate(_pointTextPrefab, transform.position, transform.rotation);
        pointText.GetComponent<TMP_Text>().text = "+" + points.Value + "x" + _scoreMultiplier.Value;
        pointText.transform.SetParent(transform.parent);

        // increase the score multiplier for consecutive kills; don't increase it past the max multiplier
        _score.Value += points.Value * _scoreMultiplier.Value;
        _scoreMultiplier.Value += 1f;
        _scoreMultiplier.Value = Mathf.Clamp(_scoreMultiplier.Value, 0f, _maxScoreMultiplier.Value);

        _scoreSound.Play();

        _shakeAmount.Value = 1f;
    }
}
