using Scripts.CameraScripts;
using Scripts.PlayerScripts;
using UnityEngine;

namespace Scripts.NotepadScripts
{
    public class NotepadController : MonoCache
    {
        [SerializeField] PlayerMovement playerMovement;
        [SerializeField] CameraController cameraController;
        [SerializeField] CrouchController crouchController;
        [SerializeField] JumpController jumpController;

        [SerializeField] private GameObject itemsForCarRepair;
        [SerializeField] private GameObject itemsForSurvivalInNight;

        [SerializeField] Animator animator;
        int keyPress = 0;

        public override void OnTick()
        {
            OpenAndCloseNotepad();
        }

        public void OpenAndCloseNotepad()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                switch (keyPress)
                {
                    case 0:
                        keyPress = 1;
                        animator.SetBool("isOpenNotepad", true);

                        playerMovement.enabled = false; // when a player open the notepad, the player cant walk or run
                        cameraController.enabled = false; // and rotate a camera
                        crouchController.enabled = false;
                        jumpController.enabled = false;
                        
                        itemsForCarRepair.SetActive(false);
                        itemsForSurvivalInNight.SetActive(true);
                        break;

                    case 1:
                        keyPress = 0;
                        animator.SetBool("isOpenNotepad", false);

                        playerMovement.enabled = true;
                        cameraController.enabled = true;
                        crouchController.enabled = true;
                        jumpController.enabled = true;
                        
                        break;
                }
            }
        }
    }
}
