using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(fileName = "Level", menuName = "Level Design/Level", order = 1)]
public class Level : ScriptableObject
{
    [SerializeField] private string _levelName;
    [SerializeField] private SpriteDictionary _graphics;
    [SerializeField] private MusicTrack _music;
}
