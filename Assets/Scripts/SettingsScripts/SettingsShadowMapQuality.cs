using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SettingsShadowMapQuality : MonoBehaviour
{
    [SerializeField] HDAdditionalLightData hdAdditionalLightData;

    [SerializeField] TMP_Text shadowMapQualityLabel;
    [SerializeField] TMP_Dropdown shadowMapQualityDropdown;

    internal bool isHasEditSetgginsShadowMapQuality = false;

    public void ShadowMapQuality(int currentShadowMapQuality) 
    {
        switch (currentShadowMapQuality) 
        {
            case 0:
                hdAdditionalLightData.EnableShadows(false);

                shadowMapQualityLabel.text = "Shadow Map Quality*";
                isHasEditSetgginsShadowMapQuality = true;

                break;

            case 1:
                ChangeShadowMapQuality();
                hdAdditionalLightData.shadowResolution.level = 0;
                break;

            case 2:
                ChangeShadowMapQuality();
                hdAdditionalLightData.shadowResolution.level = 1;
                break;

            case 3:
                ChangeShadowMapQuality();
                hdAdditionalLightData.shadowResolution.level = 2;
                break;

            case 4:
                ChangeShadowMapQuality();
                hdAdditionalLightData.shadowResolution.level = 3;
                break;
        }
    }

    public void ChangeShadowMapQuality() 
    {
        hdAdditionalLightData.EnableShadows(true);

        shadowMapQualityLabel.text = "Shadow Map Quality*";
        isHasEditSetgginsShadowMapQuality = true;
    }

    public void SaveShadowMapQuality() 
    {
        PlayerPrefs.SetInt(CommonSettingsData.SettingsKeys.ShadowMapQualityKey, shadowMapQualityDropdown.value);
        RemoveSpecialSignFromShadowMapQuality();

    }

    public void LoadShadowMapQuality() 
    {
        if (PlayerPrefs.HasKey(CommonSettingsData.SettingsKeys.ShadowMapQualityKey))
            shadowMapQualityDropdown.value = PlayerPrefs.GetInt(CommonSettingsData.SettingsKeys.ShadowMapQualityKey);

        RemoveSpecialSignFromShadowMapQuality();
    }

    public void RemoveSpecialSignFromShadowMapQuality() 
    {
        shadowMapQualityLabel.text = "Shadow Map Quality";
        isHasEditSetgginsShadowMapQuality = false;
    }

}
