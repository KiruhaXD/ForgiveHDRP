using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Scripts.OdinSerializerSavesAndLoads;

namespace Scripts.InteractScripts
{
    public class BoltsInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForBoltsMission;
        [SerializeField] GameObject interfaceMissionForBolts;

        [SerializeField] TMP_Text tmpTextTakeItem;
    
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with bolts"); // active toggle in a notepad and disable mission
                toggleInNotepadForBoltsMission.isOn = true;
                interfaceMissionForBolts.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take bolts";
            return tmpTextTakeItem.text;
        }

    }
}


