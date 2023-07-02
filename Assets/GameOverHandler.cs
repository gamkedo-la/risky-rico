using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{   

    [SerializeField] private float _slowDownRate = 0.01f;
    [SerializeField] private float _gameOverTimer;
    private bool _sequenceStarted = false;

    public void StartGameOverSequence()
    {
        _sequenceStarted = true;
    }
    
    void Update()
    {
        if (_sequenceStarted)
        {
            // lerp slow-mo
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, _slowDownRate);
        }

        // scene change on countdown finish
        if (Time.timeScale <= 0.02f && _sequenceStarted)
        {
            _gameOverTimer -= Time.unscaledDeltaTime;
            if (_gameOverTimer <= 0f)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("gameover");
                _sequenceStarted = false;
            }
        }
    }
}
