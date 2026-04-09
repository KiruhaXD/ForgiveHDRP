using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts.InteractScripts
{
    public class LugWrenchInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForLugWrenchMission;
        [SerializeField] GameObject interfaceMissionForLugWrench;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            Debug.Log("Interact with a lug wrench"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForLugWrenchMission);

            interfaceMissionForLugWrench.SetActive(false);
        }

        public string Description() 
        {
            CommonDescriptionItem(tmpTextTakeItem, "Take a lug wrench");
            return tmpTextTakeItem.text;
        } 
    }
}


