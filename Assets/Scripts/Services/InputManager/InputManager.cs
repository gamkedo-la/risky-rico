using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// The InputManager class is responsible for 
/// <br/><br/>
/// Global Access to the InputManager is available from the ServiceLocator<br/>
/// How to Access: ServiceLocator.Instance.Get&lt;InputManager&gt;();
/// </summary>
public class InputManager : IService
{
    // These are setting parameters stored in a ScriptableObject under "Assets/Settings/AudioSetting/InputManagerParams"
    // private readonly PlayerControls _params = Resources.Load<InputManagerParams>("Audio/InputManagerParams");
    private readonly GameObject _InputManagerGameObject;
    private PlayerControls _playerControls;
    public InputManager()
    {
        // Create a new GameObject to hold audioSources for us
        _InputManagerGameObject = new GameObject("InputManagerGameObject");
        Object.DontDestroyOnLoad(_InputManagerGameObject);        
        _InputManagerGameObject.AddComponent<InputHandler>();
    }

    ~InputManager()
    {
        Object.Destroy(_InputManagerGameObject);
    }
}