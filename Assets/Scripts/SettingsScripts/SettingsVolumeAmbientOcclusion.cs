using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsVolumeAmbientOcclusion : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile profile;

    [SerializeField] Toggle ambientOcclusionToggle;
    [SerializeField] TMP_Dropdown ambientOcclusionQualityDropdown;

    [SerializeField] TMP_Text ambientOcclusionToggleLabel;
    [SerializeField] TMP_Text ambientOcclusionQualityLabel;

    int ambientOcclusionToggleIsOn = 0; // 0 - false, 1 - true
    int ambientOcclusionQualityVisibleDropdown = 0;

    internal bool isHasEditAmbientOcclusionQuality = false;

    public void ClickToggleAmbientOcclusion() 
    {
        profile = volume.sharedProfile;

        if (profile.TryGet<ScreenSpaceAmbientOcclusion>(out var ambientOcclusion))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "GameScene":

                    if (ambientOcclusionToggle.isOn == false)
                        SaveOFFToggleAmbientOcclusion(ambientOcclusion);

                    else
                        SaveONToggleAmbientOcclusion(ambientOcclusion);
                    
                    break;

                case "MainMenuSceneDay":

                    if (ambientOcclusionToggle.isOn == false)
                        SaveOFFToggleAmbientOcclusion(ambientOcclusion);
                    
                    else
                        SaveONToggleAmbientOcclusion(ambientOcclusion);

                    break;
            }

        }
    }

    public void AmbientOcclusionQuality(int indexAmbientOcclusion)
    {
        profile = volume.sharedProfile;

        if (profile.TryGet<ScreenSpaceAmbientOcclusion>(out var ambientOcclusion))
            ambientOcclusion.quality.value = indexAmbientOcclusion;         

        ambientOcclusionQualityLabel.text = "Ambient Occlusion Quality*";
        isHasEditAmbientOcclusionQuality = true;
    }

    public void SaveONToggleAmbientOcclusion(ScreenSpaceAmbientOcclusion ambientOcclusion) 
    {
        ambientOcclusion.active = true;
        ambientOcclusionToggleIsOn = 1;
        PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.ShowAmbientOcclusionToggleKey, ambientOcclusionToggleIsOn);

        ambientOcclusionQualityDropdown.interactable = true;
        ambientOcclusionQualityVisibleDropdown = 1;

        PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.HideAmbientOcclusionToggleKey);

    }

    public void SaveOFFToggleAmbientOcclusion(ScreenSpaceAmbientOcclusion ambientOcclusion) 
    {
        ambientOcclusion.active = false;
        ambientOcclusionToggleIsOn = 0;
        PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.HideAmbientOcclusionToggleKey, ambientOcclusionToggleIsOn);

        ambientOcclusionQualityDropdown.interactable = false;
        ambientOcclusionQualityVisibleDropdown = 0;

        PlayerPrefs.DeleteKey(CommonSettingsData.SettingsKeys.ShowAmbientOcclusionToggleKey);
    }

    public void SaveAmbientOcclusionSettings() 
    {
        PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.AmbientOcclusionQualityKey, ambientOcclusionQualityDropdown.value);
        PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.AmbientOcclusionQualityVisibleKey, ambientOcclusionQualityVisibleDropdown);

        RemoveSpecialSignAfterEditAmbientOcclusionQuality();
    }

    public void RemoveSpecialSignAfterEditAmbientOcclusionQuality() // убрать знак "*"
    {     
        ambientOcclusionQualityLabel.text = "Ambient Occlusion Quality";
        isHasEditAmbientOcclusionQuality = false;
    }

    public void CheckKeyForAmbientOcclusionToggle()
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.ShowAmbientOcclusionToggleKey))
        {
            ambientOcclusionToggleIsOn = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.ShowAmbientOcclusionToggleKey);
            ambientOcclusionToggle.isOn = true;
        }

        else if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.HideAmbientOcclusionToggleKey))
        {
            ambientOcclusionToggleIsOn = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.HideAmbientOcclusionToggleKey);
            ambientOcclusionToggle.isOn = false;
        }
    }

    public void LoadAmbientOcclusionQualitySettings() 
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.AmbientOcclusionQualityKey) && PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.AmbientOcclusionQualityVisibleKey))
        {
            ambientOcclusionQualityDropdown.value = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.AmbientOcclusionQualityKey);
            ambientOcclusionQualityVisibleDropdown = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.AmbientOcclusionQualityVisibleKey);
        }

        RemoveSpecialSignAfterEditAmbientOcclusionQuality();
    }
}
