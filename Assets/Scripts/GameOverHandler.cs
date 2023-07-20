using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScriptableObjectArchitecture;

public class GameOverHandler : MonoBehaviour
{

    [SerializeField] private float _slowDownRate = 0.01f;
    [SerializeField] private float _gameOverTimer;
    [SerializeField] private IntVariable _gold;
    [SerializeField] private IntVariable _score;
    [SerializeField] private WeaponList _acquiredWeapons;
    [SerializeField] private PlayerAttributes _playerAttributes;
    private bool _sequenceStarted = false;

    public void StartGameOverSequence()
    {
        _sequenceStarted = true;
        ServiceLocator.Instance.Get<AudioManager>().PlaySoundFromDictionary("GameOver");
    }

    void Update()
    {
        if (_sequenceStarted)
        {
            // lerp slow-mo until it's time for the gameover transition
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, _slowDownRate);
        }

        // scene change on countdown finish
        if (Time.timeScale <= 0.02f && _sequenceStarted)
        {
            _gameOverTimer -= Time.unscaledDeltaTime;
            if (_gameOverTimer <= 0f)
            {
                // bring our timescale back to normal
                Time.timeScale = 1f;

                // lose all gold collected in the dungeon, but convert points into new gold
                _gold.Value = 0;
                _gold.Value = (int)Mathf.Floor((float)_score.Value / 10f);
                ServiceLocator.Instance.Get<SaveDataManager>().SetOnHandMoney(_gold.Value);

                // lose all weapons purchased or collected in the dungeon
                _acquiredWeapons.Clear();
                _acquiredWeapons.Add(_playerAttributes.DefaultWeapon);
                _playerAttributes.SetCurrentWeapon(_playerAttributes.DefaultWeapon);

                // set flags for entering the dungeon for the first time
                SaveDataManager dataManager = ServiceLocator.Instance.Get<SaveDataManager>();
                bool haveEnteredDungeonBefore = dataManager.GetFlag(dataManager.enteredDungeon);

                if (!haveEnteredDungeonBefore)
                {
                    dataManager.SetFlag(dataManager.enteredDungeon, true);
                    dataManager.SetFlag(dataManager.meetHellWell, true);
                    dataManager.SetFlag(dataManager.meetTippy, true);
                    dataManager.SetFlag(dataManager.meetShopKeeper, true);
                }

                // move to game over menu
                SceneManager.LoadScene("gameover");
                _sequenceStarted = false;
            }
        }
    }
}
