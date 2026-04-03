using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scripts.OdinSerializerSavesAndLoads;

namespace Scripts.InteractScripts
{
    public class BoltsInteraction : CommonInteractionItems, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForBoltsMission;
        [SerializeField] GameObject interfaceMissionForBolts;

        [SerializeField] TMP_Text tmpTextTakeItem;
    
        public void Interact()
        {
            Debug.Log("Interact with bolts"); // active toggle in a notepad and disable mission
            CommonInteractItem(toggleInNotepadForBoltsMission);

            interfaceMissionForBolts.SetActive(false);
        }

        public void Description() => CommonDescriptionItem(tmpTextTakeItem, "Take bolts");

    }
}


