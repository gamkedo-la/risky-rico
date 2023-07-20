using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : IService
{
    private readonly string highScoresKey = "HighScores";

    // Money Keys
    private readonly string despositedMoneyKey = "depositedMoney";
    private readonly string onHandMoney = "onHandMoney";

    //Settings Keys
    private readonly string masterVolumeKey = "MasterVolume";
    private readonly string musicVolumeKey = "MusicVolume";
    private readonly string sfxVolumeKey = "SFXVolume";
    private readonly string resolutionKey = "Resolution";
    private readonly string screenShakeKey = "ScreenShake";
    private readonly string flashingEffectKey = "FlashingEffects";

    // Dialog flags
    private readonly string paidHellWellForLore_1 = "paidHellWellForLore_1";
    private readonly string paidHellWellForLore_2 = "paidHellWellForLore_2";

    // Intro flags
    public readonly string finishedTutorial = "finishedTutorial";
    public readonly string enteredDungeon = "enteredDungeon";
    public readonly string meetShopKeeper = "meetShopKeeper";
    public readonly string meetTippy = "meetTippy";
    public readonly string meetHellWell = "meetHellWell";

    public SaveDataManager()
    {
        PlayerPrefs.Save();
    }

    // 1 for true, 0 for false
    public bool GetFlag(string flagKey)
    {
        string flagValue = PlayerPrefs.GetString(flagKey, "0");
        return flagValue == "1";
    }

    public void SetFlag(string flagKey, bool value)
    {
        string flagValue = value ? "1" : "0";
        PlayerPrefs.SetString(flagKey, flagValue);
    }

    public List<Score> GetHighScores()
    {
        string scores = PlayerPrefs.GetString(highScoresKey, "");
        if (scores == "")
        {
            return new List<Score>();
        }
        return JsonUtility.FromJson<List<Score>>(scores);
    }
    public void SetHighScores(List<Score> highScores)
    {
        PlayerPrefs.SetString(highScoresKey, JsonUtility.ToJson(highScores));
    }

    public int GetOnHandMoney()
    {
        return PlayerPrefs.GetInt(onHandMoney, 0);
    }

    public void SetOnHandMoney(int money)
    {
        PlayerPrefs.SetInt(onHandMoney, money);
    }

    public int GetDepositedMoney()
    {
        return PlayerPrefs.GetInt(despositedMoneyKey, 0);
    }
    public void SetDespositedMoney(int money)
    {
        PlayerPrefs.SetInt(despositedMoneyKey, money);
    }

    public float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(masterVolumeKey, 0.75f);
    }

    public void SetMasterVolume(float masterVolume)
    {
        PlayerPrefs.SetFloat(masterVolumeKey, masterVolume);
    }

    public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(musicVolumeKey, 0.75f);
    }

    public void SetMusicVolume(float musicVolume)
    {
        PlayerPrefs.SetFloat(musicVolumeKey, musicVolume);
    }

    public float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(sfxVolumeKey, 0.75f);
    }

    public void SetSFXVolume(float sfxVolume)
    {
        PlayerPrefs.SetFloat(sfxVolumeKey, sfxVolume);
    }

    public Resolutions GetResolution()
    {
        string resolutions = PlayerPrefs.GetString(resolutionKey, "");
        if (resolutions == "")
        {
            return new Resolutions();
        }
        return JsonUtility.FromJson<Resolutions>(resolutions);
    }

    public void SetResolution(Resolutions resolutions)
    {
        PlayerPrefs.SetString(resolutionKey, JsonUtility.ToJson(resolutions));
    }

    public void SetScreenShake(float screenShake)
    {
        PlayerPrefs.SetFloat(screenShakeKey, screenShake);
    }

    public float GetScreenShake()
    {
        return PlayerPrefs.GetFloat(screenShakeKey, 0f);
    }

    public void SetFlashingEffects(bool flashingEffects)
    {
        PlayerPrefs.SetInt(flashingEffectKey, flashingEffects ? 1 : 0);
    }

    public bool GetFlashingEffects()
    {
        return PlayerPrefs.GetInt(flashingEffectKey, 0) != 0;
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
