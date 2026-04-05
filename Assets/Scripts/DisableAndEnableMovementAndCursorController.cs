using Scripts.CameraScripts;
using Scripts.PlayerScripts;
using UnityEngine;

namespace Scripts
{
    public class DisableAndEnableMovementAndCursorController : MonoCache
    {
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] CameraController cameraController;
        [SerializeField] CrouchController crouchController;
        [SerializeField] JumpController jumpController;

        [HideInInspector]
        public bool isGameMenuActive = false;
        [HideInInspector]
        public bool isDialogueWithSalerActive = false;

        public void EnableMovementAndHideCursor()
        {
            if(isGameMenuActive == false)
                Time.timeScale = 1;

            if (isDialogueWithSalerActive == false)
            {
                playerMovement.enabled = true;
                cameraController.enabled = true;
                crouchController.enabled = true;
                jumpController.enabled = true;
            }

            HideCursor();
        }

        public void DisableMovementAndShowCursor()
        {
            if(isGameMenuActive == true)
                Time.timeScale = 0;

            if (isDialogueWithSalerActive == true) 
            {
                playerMovement.enabled = false;
                cameraController.enabled = false;
                crouchController.enabled = false;
                jumpController.enabled = false;
            }

            ShowCursor();
        }

        public void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void ShowCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
