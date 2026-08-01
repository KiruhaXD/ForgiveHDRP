using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _Project.Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class ItemShopInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] string nameItem;

        [SerializeField] Toggle toggleInNotepadForItemMission;
    
        [SerializeField] TMP_Text tmpTextTakeItem;

        public void Interact()
        {
            Debug.Log($"Interact with a {nameItem}"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForItemMission);
        }

        public void Description()
        {
            CommonDescriptionItem(tmpTextTakeItem, $"Take a {nameItem}");
            //return tmpTextTakeItem.text;
        }
    }
}


