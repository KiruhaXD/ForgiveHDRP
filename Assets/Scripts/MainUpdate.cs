using Scripts.FlashlightScripts;
using Scripts.InterfaceScripts;
using Scripts.GameMenuScripts;
using Scripts.NotepadScripts;
using UnityEngine;

namespace Scripts
{
    public class MainUpdate : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] FlashlightController flashlightController;
        [SerializeField] StaminaSliderController staminaSlider;
        [SerializeField] NotepadController notepadController;
        [SerializeField] GameMenu gameMenu;

        void Update()
        {
            // FlashlightController.cs
            flashlightController.OnAndOffLight();

            // StaminaSliderController.cs
            staminaSlider.CheckStaminaSlider();

            // NotepadController.cs
            notepadController.OpenAndCloseNotepad();
            
            // GameMenu.cs
            gameMenu.ShowPanelMenuButtons();
        }
    }
}
