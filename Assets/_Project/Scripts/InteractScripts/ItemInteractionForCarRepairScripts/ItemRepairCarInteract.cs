using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.InteractScripts.ItemInteractionForCarRepairScripts
{
    public class ItemRepairCarInteract : CommonInteractionItems, IInteractable
    {
        [SerializeField] string nameItemRepair;

        [SerializeField] Toggle toggleInNotepadItemRepairCarMission;

        [SerializeField] TMP_Text tmpTextTakeItem;
    
        public void Interact()
        {
            Debug.Log($"Interact with a {nameItemRepair}"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadItemRepairCarMission);
        }

        public void Description()
        {
            CommonDescriptionItem(tmpTextTakeItem, $"Take a {nameItemRepair}");
            //return tmpTextTakeItem.text;
        }
    }
}


