using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsVolumeLensFlare : MonoBehaviour
{
    [SerializeField] Toggle toggleLensFlare;

    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile volumeProfile;

    [SerializeField] TMP_Text lensFlareLabel;

    int isShowLensFlare = 0; // 0 - false, 1- true

    internal bool isHasEditSettingsLensFlare = false;

    public void ShowOrHideLensFlare() 
    {
        volumeProfile = volume.sharedProfile;

        if (volumeProfile.TryGet<ScreenSpaceLensFlare>(out var lensFlare)) 
        {
            if (toggleLensFlare.isOn == true)
            {
                lensFlare.active = true;
                isShowLensFlare = 1;
            }

            else
            {
                lensFlare.active = false;
                isShowLensFlare = 0;
            }

            lensFlareLabel.text = "Lens Flare*";
            isHasEditSettingsLensFlare = true;
        }
    }

    public void SaveLensFlareShowOrHide()
    {
        if (toggleLensFlare.isOn == true && isShowLensFlare == 1)
        {
            PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.ShowLensFlareKey, isShowLensFlare);
            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.HideLensFlareKey);
        }

        else if (toggleLensFlare.isOn == false && isShowLensFlare == 0)
        {
            PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.HideLensFlareKey, isShowLensFlare);
            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.ShowLensFlareKey);
        }

        RemoveSpecialSignForLensFlareSettings();

    }

    public void LoadLensFlareShowOrHide()
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.ShowLensFlareKey))
        {
            isShowLensFlare = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.ShowLensFlareKey);
            toggleLensFlare.isOn = true;
        }

        else if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.HideLensFlareKey))
        {
            isShowLensFlare = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.HideLensFlareKey);
            toggleLensFlare.isOn = false;
        }

        RemoveSpecialSignForLensFlareSettings();
    }

    public void RemoveSpecialSignForLensFlareSettings()
    {
        lensFlareLabel.text = "Lens Flare";
        isHasEditSettingsLensFlare = false;
    }
}
