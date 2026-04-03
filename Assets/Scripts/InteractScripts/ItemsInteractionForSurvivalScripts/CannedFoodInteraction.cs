using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class CannedFoodInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForCannedFoodMission;
        //[SerializeField] GameObject interfaceMissionForCannedFood;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            Debug.Log("Interact with a canned food"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForCannedFoodMission);

            //interfaceMissionForCannedFood.SetActive(false);
        }

        public void Description() => CommonDescriptionItem(tmpTextTakeItem, "Take a canned food");
    }
}


