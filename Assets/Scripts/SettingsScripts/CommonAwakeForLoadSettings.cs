using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonAwakeForLoadSettings : MonoBehaviour
{
    [SerializeField] SettingsGraphics settingsGraphics;
    [SerializeField] SettingsVolumeAmbientOcclusion settingsVolumeAmbientOcclusion;
    [SerializeField] SettingsVolumeFogQuality settingsVolumeFogQuality;
    [SerializeField] SettingsShadowMapQuality settingsShadowMapQuality;
    [SerializeField] SettingsContactShadows settingsContactShadows;
    [SerializeField] SettingsVolumeCascadedShadowMaps settingsVolumeShadowsQuality;
    [SerializeField] SettingVolumeMicroShadows settingsVolumeMicroShadows;
    [SerializeField] SettingsVolumeLensFlare settingsVolumeLensFlare;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            settingsGraphics.CheckKeysFPSForPlayerPrefs();

            settingsVolumeAmbientOcclusion.CheckKeyForAmbientOcclusionToggle();
            settingsVolumeAmbientOcclusion.LoadAmbientOcclusionQualitySettings();

            settingsVolumeFogQuality.LoadFogQualitySettings();

            settingsShadowMapQuality.LoadShadowMapQuality();
            settingsContactShadows.LoadContactShadows();
            settingsVolumeShadowsQuality.LoadCascadedShadowMapShowOrHide();
            settingsVolumeMicroShadows.LoadMicroShadowsShowOrHide();
            settingsVolumeLensFlare.LoadLensFlareShowOrHide();
        }

        else if (SceneManager.GetActiveScene().name == "MainMenuSceneDay")
        {
            settingsGraphics.CheckKeysFPSForPlayerPrefs();

            settingsVolumeAmbientOcclusion.CheckKeyForAmbientOcclusionToggle();
            settingsVolumeAmbientOcclusion.LoadAmbientOcclusionQualitySettings();

            settingsVolumeFogQuality.LoadFogQualitySettings();

            settingsShadowMapQuality.LoadShadowMapQuality();
            settingsContactShadows.LoadContactShadows();
            settingsVolumeShadowsQuality.LoadCascadedShadowMapShowOrHide();
            settingsVolumeMicroShadows.LoadMicroShadowsShowOrHide();
            settingsVolumeLensFlare.LoadLensFlareShowOrHide();
        }
    }
}
