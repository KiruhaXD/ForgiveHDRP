using DigitalRuby.RainMaker;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsRain : MonoBehaviour
{
    [SerializeField] RainScript rainScript;
    [SerializeField] Toggle toggleRain;
    [SerializeField] TMP_Text rainLabel;

    [HideInInspector]
    public bool isHasEditSettingsRain = false;

    public void ChangeRainToggle() 
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "GameScene":

                if (toggleRain.isOn == true)
                {
                    RainON();
                    ChangeRainSettings();
                }

                else
                {
                    RainOFF();
                    ChangeRainSettings();
                }

                break;

            case "MainMenuSceneDay":

                if (toggleRain.isOn == true)
                {
                    RainON();
                    ChangeRainSettings();
                }

                else
                {
                    RainOFF();
                    ChangeRainSettings();
                }

                break;
        }
    }

    public float RainON() 
    {
        return rainScript.RainIntensity = 0.3f;
    }

    public float RainOFF() 
    {
        return rainScript.RainIntensity = 0f;
    }

    public void ChangeRainSettings() 
    {
        rainLabel.text = "Rain*";
        isHasEditSettingsRain = true;
    }

    public void RemoveSpecialSignForRain() 
    {
        rainLabel.text = "Rain";
        isHasEditSettingsRain = false;
    }

    public void SaveSettingsRainONAndOFF() 
    {
        if (toggleRain.isOn == true)
        {
            PlayerPrefs.SetFloat(CommonSettingsData.SettingsKeys.ShowRainKey, RainON());

            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.HideRainKey);
        }

        else 
        {
            PlayerPrefs.SetFloat(CommonSettingsData.SettingsKeys.HideRainKey, RainOFF());

            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.ShowRainKey);
        }

        RemoveSpecialSignForRain();
    }

    public void LoadSettingsRainONAndOFF() 
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.ShowRainKey))
        {
            rainScript.RainIntensity = PlayerPrefs.GetFloat(CommonSettingsData.SettingsKeys.ShowRainKey);

            toggleRain.isOn = true;
        }

        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.HideRainKey))
        {
            rainScript.RainIntensity = PlayerPrefs.GetFloat(CommonSettingsData.SettingsKeys.HideRainKey);

            toggleRain.isOn = false;
        }

        RemoveSpecialSignForRain();
    }
}
