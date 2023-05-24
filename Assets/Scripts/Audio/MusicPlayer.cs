using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        ServiceLocator.Instance.Get<MusicManager>().StartSong("Combat", 0, false);
    }
}
