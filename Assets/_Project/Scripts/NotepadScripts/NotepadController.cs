using Scripts.PlayerScripts;
using UnityEngine;

namespace Scripts.NotepadScripts
{
    public class NotepadController : MonoCache
    {
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

                        crouchController.enabled = false;
                        jumpController.enabled = false;
                        
                        itemsForCarRepair.SetActive(false);
                        itemsForSurvivalInNight.SetActive(true);
                        break;

                    case 1:
                        keyPress = 0;
                        animator.SetBool("isOpenNotepad", false);

                        crouchController.enabled = true;
                        jumpController.enabled = true;
                        
                        break;
                }
            }
        }
    }
}
