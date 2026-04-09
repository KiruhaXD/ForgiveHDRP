using Scripts.InteractScripts;
using TMPro;
using UnityEngine;

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

    public string Description() 
    {
        if(!isOpen)
            tmpTextInteractDoor.text = "Open a door";
        else
            tmpTextInteractDoor.text = "Close a door";

        return tmpTextInteractDoor.text;
    } 
    
}
