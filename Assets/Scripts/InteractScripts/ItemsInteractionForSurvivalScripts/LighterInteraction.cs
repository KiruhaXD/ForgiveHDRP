using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class LighterInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForLighterMission;
        //[SerializeField] GameObject interfaceMissionForLighter;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            Debug.Log("Interact with a lighter"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForLighterMission);

            //interfaceMissionForLighter.SetActive(false);
        }

        public void Description() => CommonDescriptionItem(tmpTextTakeItem, "Take a lighter");
    }
}


