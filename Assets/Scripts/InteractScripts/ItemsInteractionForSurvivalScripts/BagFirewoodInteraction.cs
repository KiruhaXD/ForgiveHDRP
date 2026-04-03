using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class BagFirewoodInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForBagFirewoodMission;
        //[SerializeField] GameObject interfaceMissionForBagFirewood;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            Debug.Log("Interact with a bag firewood"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForBagFirewoodMission);

            //interfaceMissionForBagFirewood.SetActive(false);
        }

        public void Description() => CommonDescriptionItem(tmpTextTakeItem, "Take a bag firewood");
    }
}


