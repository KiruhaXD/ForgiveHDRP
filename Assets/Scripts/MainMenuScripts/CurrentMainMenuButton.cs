using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Scripts.MainMenuScripts
{
    public class CurrentMainMenuButton : MonoBehaviour
    {
        [SerializeField] MainMenu mainMenu;

        [SerializeField] TMP_Text currentTmpText;
        [SerializeField] SpriteRenderer currentSpriteRenderer;

        [SerializeField] AudioSource audioSourceUI;

        private void Awake()
        {
            if (PlayerPrefs.HasKey(CheckpointController.CanContinueGameKey))
            {
                CheckpointController.continueGame = PlayerPrefs.GetInt(CheckpointController.CanContinueGameKey);
            }
        }

        private void OnMouseDown()
        {
            switch (currentTmpText.name)
            {
                case "Text (TMP) NEW GAME":
                    mainMenu.HideMainMenu();
                    mainMenu.confirmationWindowForNewGame.SetActive(true);
                    break;

                case "Text (TMP) CONTINUE":
                    if (CheckpointController.continueGame == 1)
                        mainMenu.LoadGameControlPanel();
                    break;

                /*case "Text (TMP) LOAD GAME":
                    mainMenu.HideMainMenu();
                    mainMenu.loadGameWindow.SetActive(true);
                    mainMenu.panelMenuSavesGames.SetActive(true);
                    break;*/

                case "Text (TMP) AUTHORS":
                    mainMenu.HideMainMenu();
                    mainMenu.authorsWindow.SetActive(true);
                    break;

                case "Text (TMP) EXIT GAME":
                    mainMenu.HideMainMenu();
                    mainMenu.confirmationWindowForExitGame.SetActive(true);
                    break;

                case "Text (TMP) SETTINGS":
                    mainMenu.HideMainMenu();
                    mainMenu.settingsWindow.SetActive(true);
                    break;
            }
        }

        private void OnMouseEnter()
        {
            if (currentTmpText.name == "Text (TMP) NEW GAME" || currentTmpText.name == "Text (TMP) AUTHORS"
                || currentTmpText.name == "Text (TMP) EXIT GAME" || currentTmpText.name == "Text (TMP) SETTINGS"
                || currentTmpText.name == "Text (TMP) CONTINUE" && CheckpointController.continueGame == 1)
            {
                EnterButton();
            }
        }

        private void OnMouseExit()
        {
            if (currentTmpText.name == "Text (TMP) NEW GAME" || currentTmpText.name == "Text (TMP) AUTHORS"
                || currentTmpText.name == "Text (TMP) EXIT GAME" || currentTmpText.name == "Text (TMP) SETTINGS"
                || currentTmpText.name == "Text (TMP) CONTINUE" && CheckpointController.continueGame == 1)
            {
                ExitButton();
            }
        }

        public void EnterButton() 
        {
            currentTmpText.DOColor(new Color(0, 0, 0, 255), 0.2f);
            currentSpriteRenderer.DOColor(new Color(0, 0, 0, 255), 0.2f);
            transform.DOScale(new Vector3(0.024f, 0.024f, 0.024f), 0.2f);

            audioSourceUI.Play();
        }

        public void ExitButton() 
        {
            currentTmpText.DOColor(new Color(255, 255, 255, 255), 0.2f);
            currentSpriteRenderer.DOColor(new Color(255, 255, 255, 255), 0.2f);
            transform.DOScale(new Vector3(0.025f, 0.025f, 0.025f), 0.2f);
        }
    }
}
