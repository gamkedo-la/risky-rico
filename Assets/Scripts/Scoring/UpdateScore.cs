using UnityEngine;
using ScriptableObjectArchitecture;
using TMPro;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] private IntVariable _score;
    [SerializeField] private IntVariable _scoreMultiplier;
    [SerializeField] private IntVariable _maxScoreMultiplier;
    [SerializeField] private FloatVariable _shakeAmount;
    [SerializeField] private GameObject _pointTextPrefab;
    [SerializeField] private SoundEffect _scoreSound;

    void Awake()
    {
        _score.Value = 0;
        _scoreMultiplier.Value = 1;
    }

    public void BreakCombo()
    {
        // spawn text object to show combo break
        if (_scoreMultiplier.Value > 1)
        {
            GameObject combobreakText = Instantiate(_pointTextPrefab, transform.position, transform.rotation);
            combobreakText.GetComponent<TMP_Text>().text = "<color=#ac3232>x0</color>";
            combobreakText.transform.SetParent(transform.parent);
        }

        // reset combo multiplier
        _scoreMultiplier.Value = 1;
    }

    public void IncreaseScore(IntVariable points)
    {
        // spawn text object to show score increase
        GameObject pointText = Instantiate(_pointTextPrefab, transform.position, transform.rotation);
        pointText.GetComponent<TMP_Text>().text = "+" + points.Value + "x" + _scoreMultiplier.Value;
        pointText.transform.SetParent(transform.parent);

        // increase the score multiplier for consecutive kills; don't increase it past the max multiplier
        _score.Value += points.Value * _scoreMultiplier.Value;
        _scoreMultiplier.Value += 1;
        _scoreMultiplier.Value = Mathf.Clamp(_scoreMultiplier.Value, 0, _maxScoreMultiplier.Value);

        _scoreSound.Play();

        _shakeAmount.Value = 1f;
    }
}
