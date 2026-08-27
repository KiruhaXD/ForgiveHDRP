using _Project.Scripts.DialogueSystem.DialogueWithSalerScripts;
using _Project.Scripts.InventoryScripts;
using _Project.Scripts.PlayerScripts;
using EasyRoads3Dv3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.InteractScripts.CarInteractScripts
{
    // скрипт отвечающий за взаимодействие с дверью машины
    public class InteractionDoorCar : MonoBehaviour, IInteractable
    {
        [SerializeField] TMP_Text textInteractionDoorCar;

        [Header("Animator")]
        [SerializeField] Animator playerAnimator;
        [SerializeField] Animator carAnimator;

        [Header("References From Other Classes")]
        [SerializeField] TransitionsController transitionsController;
        [SerializeField] CheckCompleteTasksNotepad checkCompleteTasksNotepad;
        [SerializeField] DialogueWithSaler dialogueWithSaler;
        [SerializeField] DrivingPlayer drivingPlayer;

        public void Interact()
        {
            /*if (checkCompleteTasksNotepad.completeMissionItemsForSurvival == true && dialogueWithSaler.hasBoughtItemsInShop == true) 
            {
                drivingPlayer.isInCar = true;

                playerAnimator.SetBool("isEnteringCar", true);

                carAnimator.SetBool("isOpenDoor", true);

                transitionsController.TransitionTeleportCar();
            }*/

            drivingPlayer.isInCar = true;

            playerAnimator.SetBool("isEnteringCar", true);

            playerAnimator.SetBool("isExitingCar", false); // off transition to animation clip

            carAnimator.SetBool("isOpenDoor", true);

            Debug.LogWarning("isEnteringCar = true");

            transitionsController.TransitionTeleportCar();
        }

        public void Description()
        {
            textInteractionDoorCar.text = "sit in the car";
            //return textInteractionDoorCar.text;
        }
    }


}