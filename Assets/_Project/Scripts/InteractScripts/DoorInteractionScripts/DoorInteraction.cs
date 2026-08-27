using TMPro;
using UnityEngine;

namespace _Project.Scripts.InteractScripts.DoorInteractionScripts
{
    // скрипт отвечающий за взаимодействие с дверью
    public class DoorInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] TMP_Text tmpTextInteractDoor;
        [SerializeField] Animator doorAnimator;

        bool isOpen = false;

        public void Interact()
        {
            if (!isOpen)
                doorAnimator.SetBool("isOpen", true);
            else
                doorAnimator.SetBool("isOpen", false);

            isOpen = !isOpen;
        }

        public void Description()
        {
            if (!isOpen)
                tmpTextInteractDoor.text = "Open a door";
            else
                tmpTextInteractDoor.text = "Close a door";

            //return tmpTextInteractDoor.text;
        }

    }
}
