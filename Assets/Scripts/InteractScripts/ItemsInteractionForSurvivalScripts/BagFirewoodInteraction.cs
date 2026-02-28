using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class BagFirewoodInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForBagFirewoodMission;
        //[SerializeField] GameObject interfaceMissionForBagFirewood;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a bag firewood"); // active toggle in a notepad and disable mission
                toggleInNotepadForBagFirewoodMission.isOn = true;
                //interfaceMissionForBagFirewood.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a bag firewood";
            return tmpTextTakeItem.text;
        }
    }
}


