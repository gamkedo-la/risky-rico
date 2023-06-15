using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : IService
{
    private readonly LevelManagerParams _params = Resources.Load<LevelManagerParams>("Level Design/LevelManagerParams");
    
    public LevelManager() {}

    ~LevelManager() {}

    // if we return to the graveyard or die, set the level index to equal 0
    public void EscapeLevel()
    {
        _params.levelIndex = 0;
        SceneManager.LoadScene("graveyard");
    }

    public void GoToNextLevel()
    {
        if (_params.levelIndex < _params.levels.Count - 1)
        {
            // when exiting a level, update the index + 1 if we are not at the end of all levels
            _params.levelIndex += 1;
            Level currentLevel = _params.levels[_params.levelIndex];
    
            // if we updated the level index, load the next level as a scene
            SceneManager.LoadScene(currentLevel.LevelName);
        }
        else 
        {
            Debug.Log("Reached end level");
        }
    }

    public Level GetCurrentLevel()
    {
        return _params.levels[_params.levelIndex];
    }
}
