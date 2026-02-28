using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class SleepingBagInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForSleepingBagMission;
        //[SerializeField] GameObject interfaceMissionForSleepingBag;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a sleeping bag"); // active toggle in a notepad and disable mission
                toggleInNotepadForSleepingBagMission.isOn = true;
                //interfaceMissionForSleepingBag.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a sleeping bag";
            return tmpTextTakeItem.text;
        }
    }

}

