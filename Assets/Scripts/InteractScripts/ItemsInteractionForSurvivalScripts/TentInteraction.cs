using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class TentInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForTentMission;
        //[SerializeField] GameObject interfaceMissionForTent;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            Debug.Log("Interact with a tent"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForTentMission);

            //interfaceMissionForTent.SetActive(false);
        }

        public string Description()
        {
            CommonDescriptionItem(tmpTextTakeItem, "Take a tent");
            return tmpTextTakeItem.text;
        }
    }
}


