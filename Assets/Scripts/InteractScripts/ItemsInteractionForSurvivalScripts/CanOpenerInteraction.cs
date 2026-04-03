using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class CanOpenerInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForCanOpenerMission;
        //[SerializeField] GameObject interfaceMissionForCanOpener;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            Debug.Log("Interact with a can opener"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForCanOpenerMission);

            //interfaceMissionForCanOpener.SetActive(false);
        }

        public void Description() => CommonDescriptionItem(tmpTextTakeItem, "Take a can opener");
    }
}


