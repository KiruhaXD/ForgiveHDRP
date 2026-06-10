using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsVolumeCascadedShadowMaps : MonoBehaviour
{
    [SerializeField] Toggle toggleCascadedShadowMaps;

    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile volumeProfile;

    [SerializeField] TMP_Text cascadedShadowMapsLabel;

    int isShowCascadedShadowMaps = 0; // 0 - false, 1 - true

    internal bool isHasEditCascadedShadowMapsSettings = false;

    public void ShowOrHideCascadedShadowMap() 
    {
        volumeProfile = volume.sharedProfile;

        if (volumeProfile.TryGet<HDShadowSettings>(out var cascadedShadowMaps)) 
        {
            if (toggleCascadedShadowMaps.isOn == true)
            {
                cascadedShadowMaps.active = true;
                isShowCascadedShadowMaps = 1;
            }

            else
            {
                cascadedShadowMaps.active = false;
                isShowCascadedShadowMaps = 0;
            }

            cascadedShadowMapsLabel.text = "Cascaded Shadow Maps*";
            isHasEditCascadedShadowMapsSettings = true;
        }
    }

    public void SaveCascadedShadowMapShowOrHide() 
    {
        if (toggleCascadedShadowMaps.isOn == true && isShowCascadedShadowMaps == 1)
        {
            PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.ShowCascadedShadowMapsKey, isShowCascadedShadowMaps);
            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.HideCascadedShadowMapsKey);
        }

        else if(toggleCascadedShadowMaps.isOn == false && isShowCascadedShadowMaps == 0)
        {
            PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.HideCascadedShadowMapsKey, isShowCascadedShadowMaps);
            PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.ShowCascadedShadowMapsKey);
        }

        RemoveSpecialSignForCascadedShadowMapsSettings();

    }

    public void LoadCascadedShadowMapShowOrHide() 
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.ShowCascadedShadowMapsKey))
        {
            isShowCascadedShadowMaps = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.ShowCascadedShadowMapsKey);
            toggleCascadedShadowMaps.isOn = true;
        }

        else if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.HideCascadedShadowMapsKey)) 
        {
            isShowCascadedShadowMaps = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.HideCascadedShadowMapsKey);
            toggleCascadedShadowMaps.isOn = false;
        }

        RemoveSpecialSignForCascadedShadowMapsSettings();
    }

    public void RemoveSpecialSignForCascadedShadowMapsSettings() 
    {
        cascadedShadowMapsLabel.text = "Cascaded Shadow Maps";
        isHasEditCascadedShadowMapsSettings = false;
    }


}
