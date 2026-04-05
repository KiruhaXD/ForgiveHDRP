using Scripts.DialogueSystem.DialogueWithSalerScripts;
using Scripts.MainMenuScripts;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Scripts.GameMenuScripts
{
    public class GameMenu : DisableAndEnableMovementAndCursorController, ILoadScene
    {
        [Header("UI")]
        [SerializeField] GameObject panelMenuButtons;
        //[SerializeField] GameObject panelMenuSavesGames;
        [SerializeField] GameObject panelSettings;

        [SerializeField] GameObject panelConfirmationWindowForSaves;

        [Header("References")]
        [SerializeField] DialogueWithSaler dialogue;
        [SerializeField] SettingsGraphics settingsGraphics;
        [SerializeField] SettingsVolumeAmbientOcclusion postProcess;
        [SerializeField] SettingsVolumeFogQuality postProcessFogQuality;
        [SerializeField] SettingsShadowMapQuality settingShadowMapQuality;
        [SerializeField] SettingsContactShadows settingsContactShadows;
        [SerializeField] SettingsVolumeCascadedShadowMaps postProcessShadowsQuality;
        [SerializeField] SettingVolumeMicroShadows postProcessMicroShadows;
        [SerializeField] SettingsVolumeLensFlare postProcessLensFlare;
        [SerializeField] SettingsRain settingsRain;
        //[SerializeField] MainMenu mainMenu;

        private int pressKeyESC = 0;

        public override void OnTick()
        {
            ShowPanelMenuButtons();
        }

        public void ShowPanelMenuButtons()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && dialogue.isStartDialogue == false)
            {
                switch (pressKeyESC)
                {
                    case 0: // открыть игровое меню в игре
                        pressKeyESC = 1;
                        panelMenuButtons.SetActive(true);

                        isGameMenuActive = true;

                        DisableMovementAndShowCursor();

                        break;
                
                    case 1: // закрыть игровое меню в игре
                        pressKeyESC = 0;
                        panelMenuButtons.SetActive(false);

                        isGameMenuActive = false;

                        EnableMovementAndHideCursor();

                        break;
                }
            }

            /*if (panelMenuSavesGames.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
            {
                pressKeyESC = 1;
                panelMenuButtons.SetActive(true);
                panelMenuSavesGames.SetActive(false);

                DisableMovementAndShowCursor();
            }*/

            if (panelSettings.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
            {
                pressKeyESC = 1;

                isGameMenuActive = true;

                DisableMovementAndShowCursor();

                if (settingsGraphics.isHasEditSettingDisplay == true || settingsGraphics.isHasEditSettingResolution == true ||
                    settingsGraphics.isHasEditSettingQuality == true || settingsGraphics.isHasEditSettingDLSS == true ||
                    postProcess.isHasEditAmbientOcclusionQuality == true || settingsGraphics.isHasEditSettingsAnisotropicFiltering == true || postProcessFogQuality.isHasEditSettingsFogQuality == true ||
                    postProcessShadowsQuality.isHasEditCascadedShadowMapsSettings == true || postProcessMicroShadows.isHasEditSettingsMicroShadows == true || 
                    postProcessLensFlare.isHasEditSettingsLensFlare == true || settingsGraphics.isHasEditSettingsAntiAliazing == true || 
                    settingShadowMapQuality.isHasEditSetgginsShadowMapQuality == true || settingsContactShadows.isHasEditSettingsContactShadows == true ||
                    settingsRain.isHasEditSettingsRain == true)
                {
                    panelConfirmationWindowForSaves.SetActive(true);
                }

                else if (settingsGraphics.isHasEditSettingDisplay == false || settingsGraphics.isHasEditSettingResolution == false ||
                    settingsGraphics.isHasEditSettingQuality == false || settingsGraphics.isHasEditSettingDLSS == false ||
                    postProcess.isHasEditAmbientOcclusionQuality == false || settingsGraphics.isHasEditSettingsAnisotropicFiltering == false || postProcessFogQuality.isHasEditSettingsFogQuality == false ||
                    postProcessShadowsQuality.isHasEditCascadedShadowMapsSettings == false || postProcessMicroShadows.isHasEditSettingsMicroShadows == false || 
                    postProcessLensFlare.isHasEditSettingsLensFlare == false || settingsGraphics.isHasEditSettingsAntiAliazing == false || 
                    settingShadowMapQuality.isHasEditSetgginsShadowMapQuality == false || settingsContactShadows.isHasEditSettingsContactShadows == true ||
                    settingsRain.isHasEditSettingsRain == false) 
                {
                    panelMenuButtons.SetActive(true);
                    panelSettings.SetActive(false);
                }
            } 
        }

        /*public void ShowLoadGameMenu()
        {
            panelMenuButtons.SetActive(false);
            panelMenuSavesGames.SetActive(true);
        }*/

        public void LoadGameControlPanel()
        {
            ILoadScene.hasButtonPress = 1;

            PlayerPrefs.SetInt(ILoadScene.HasButtonPressKey, ILoadScene.hasButtonPress);
            Debug.Log("Ќажатие кнопки загрузки [—ќ’–јЌ»Ћќ—№]");

            SceneManager.LoadScene("GameScene");
        }

        public void Settings() 
        {
            panelMenuButtons.SetActive(false);
            panelSettings.SetActive(true);
        }

        public void ExitGame()
        {
            SceneManager.LoadScene("MainMenuSceneDay");
        }
    }

}
