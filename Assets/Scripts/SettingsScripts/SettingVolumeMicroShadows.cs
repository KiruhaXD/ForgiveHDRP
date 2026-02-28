using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingVolumeMicroShadows : MonoBehaviour
{
    [SerializeField] Toggle toggleMicroShadows;

    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile volumeProfile;

    [SerializeField] TMP_Text microShadowsLabel;

    int isShowMicroShadows = 0; // 0 - false, 1 - true

    internal bool isHasEditSettingsMicroShadows = false;

    public void ShowOrHideMicroShadows() 
    {
        volumeProfile = volume.sharedProfile;

        if (volumeProfile.TryGet<MicroShadowing>(out var microShadows)) 
        {
            if (toggleMicroShadows.isOn == true)
            {
                microShadows.active = true;
                isShowMicroShadows = 1;
            }

            else
            {
                microShadows.active = false;
                isShowMicroShadows = 0;
            }

            microShadowsLabel.text = "Micro Shadows*";
            isHasEditSettingsMicroShadows = true;
        }
    }

    public void SaveMicroShadowsShowOrHide() 
    {
        if (toggleMicroShadows.isOn == true && isShowMicroShadows == 1)
        {
            PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.ShowMicroShadowsKey, isShowMicroShadows);
            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.HideMicroShadowsKey);
        }

        else if (toggleMicroShadows.isOn == false && isShowMicroShadows == 0)
        {
            PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.HideMicroShadowsKey, isShowMicroShadows);
            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.ShowMicroShadowsKey);
        }

        RemoveSpecialSignForMicroShadowSettings();
    }

    public void LoadMicroShadowsShowOrHide() 
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.ShowMicroShadowsKey))
        {
            isShowMicroShadows = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.ShowMicroShadowsKey);
            toggleMicroShadows.isOn = true;
        }

        else if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.HideMicroShadowsKey))
        {
            isShowMicroShadows = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.HideMicroShadowsKey);
            toggleMicroShadows.isOn = false;
        }

        RemoveSpecialSignForMicroShadowSettings();

    }

    public void RemoveSpecialSignForMicroShadowSettings()
    {
        microShadowsLabel.text = "Micro Shadows";
        isHasEditSettingsMicroShadows = false;
    }

}
