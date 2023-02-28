using UnityEngine;
using ScriptableObjectArchitecture;

public class CameraTrauma : MonoBehaviour
{
    [SerializeField] private FloatVariable _trauma;

    public void Add(float trauma)
    {
        _trauma.Value += trauma;
    }
    public void Remove(float trauma)
    {
        _trauma.Value -= trauma;
    }

    public void Reset()
    {
        _trauma.Value = 0f;
    }
}
