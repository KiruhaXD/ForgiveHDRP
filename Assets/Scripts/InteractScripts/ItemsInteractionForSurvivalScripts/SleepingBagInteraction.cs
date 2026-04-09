using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class SleepingBagInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForSleepingBagMission;
        //[SerializeField] GameObject interfaceMissionForSleepingBag;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            Debug.Log("Interact with a sleeping bag"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForSleepingBagMission);

            //interfaceMissionForSleepingBag.SetActive(false);
        }

        public string Description()
        {
            CommonDescriptionItem(tmpTextTakeItem, "Take a sleeping bag");
            return tmpTextTakeItem.text;
        }
    }

}

