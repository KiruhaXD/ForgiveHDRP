using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class BagCoalsInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForBagCoalsMission;
        //[SerializeField] GameObject interfaceMissionForBagCoals;

        [SerializeField] TMP_Text tmpTextTakeItem;

        public void Interact()
        {
            Debug.Log("Interact with a bag coals"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForBagCoalsMission);

            //interfaceMissionForBagCoals.SetActive(false);
        }

        public string Description() 
        {
            CommonDescriptionItem(tmpTextTakeItem, "Take a bag coals");
            return tmpTextTakeItem.text;
        } 
    }
}