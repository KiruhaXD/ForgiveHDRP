using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SettingsVolumeFogQuality : MonoBehaviour
{
    [SerializeField] Volume volume;
    [SerializeField] VolumeProfile volumeProfile;

    [SerializeField] TMP_Dropdown fogQualityDropdown;
    [SerializeField] TMP_Text fogQualityLabel;

    internal bool isHasEditSettingsFogQuality = false;

    public void FogQuality(int fogQualityIndex) 
    {
        volumeProfile = volume.sharedProfile;

        if (volumeProfile.TryGet<Fog>(out var fogQuality)) 
            fogQuality.quality.value = fogQualityIndex;

        fogQualityLabel.text = "Fog Quality*";
        isHasEditSettingsFogQuality = true;
    }

    public void SaveFogQualitySettings() 
    {
        PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.FogQualitySettingsKey, fogQualityDropdown.value);

        fogQualityLabel.text = "Fog Quality";
        isHasEditSettingsFogQuality = false;
    }

    public void LoadFogQualitySettings() 
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.FogQualitySettingsKey))
            fogQualityDropdown.value = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.FogQualitySettingsKey);

        fogQualityLabel.text = "Fog Quality";
        isHasEditSettingsFogQuality = false;
    }
}
