using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private string _roomType;

    public void Awake()
    {
        LevelManager.OnLevelChange += OnLevelChange;
    }

    public void OnLevelChange()
    {
        Level currentLevel = ServiceLocator.Instance.Get<LevelManager>().GetCurrentLevel();

        if (currentLevel)
        {
            _background.sprite = currentLevel.Graphics[_roomType];
        }
    }
}
