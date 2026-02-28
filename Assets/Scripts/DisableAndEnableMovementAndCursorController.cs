using Scripts.CameraScripts;
using Scripts.PlayerScripts;
using UnityEngine;

namespace Scripts
{
    public class DisableAndEnableMovementAndCursorController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] CameraController cameraController;
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] JumpController jumpController;
        [SerializeField] CrouchController crouchController;

        public void EnableMovementAndHideCursor()
        {
            playerMovement.enabled = true;
            cameraController.enabled = true;
            crouchController.enabled = true;
            jumpController.enabled = true;

            HideCursor();
        }

        public void DisableMovementAndShowCursor()
        {
            playerMovement.enabled = false;
            cameraController.enabled = false;
            crouchController.enabled = false;
            jumpController.enabled = false;

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
