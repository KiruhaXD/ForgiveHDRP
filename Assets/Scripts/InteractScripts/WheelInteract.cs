using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.InteractScripts
{
    public class WheelInteract : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForWheelMission;
        [SerializeField] GameObject interfaceMissionForWheel;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
    
        public void Interact()
        {
            Debug.Log("Interact with wheel"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForWheelMission);

            interfaceMissionForWheel.SetActive(false);
        }

        public string Description()
        {
            CommonDescriptionItem(tmpTextTakeItem, "Take a wheel");
            return tmpTextTakeItem.text;
        }
    }
}


