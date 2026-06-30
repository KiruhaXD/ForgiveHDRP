using UnityEngine;

namespace _Project.Scripts.NotepadScripts
{
    public class NotepadController : DisableAndEnableMovementAndCursorController
    {
        [Header("Player Animation")]
        [SerializeField] PlayerAnimation playerAnimation;

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

                        DisableScripts();
                        ShowCursor();

                        playerAnimation.CallIdleAnimation();

                        itemsForCarRepair.SetActive(false);
                        itemsForSurvivalInNight.SetActive(true);
                        break;

                    case 1:
                        keyPress = 0;
                        animator.SetBool("isOpenNotepad", false);

                        EnableScripts();
                        HideCursor();

                        playerAnimation.CallIdleAnimation();

                        break;
                }
            }
        }
    }
}
