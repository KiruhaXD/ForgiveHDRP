using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class CanOpenerInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForCanOpenerMission;
        //[SerializeField] GameObject interfaceMissionForCanOpener;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a can opener"); // active toggle in a notepad and disable mission
                toggleInNotepadForCanOpenerMission.isOn = true;
                //interfaceMissionForCanOpener.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a can opener";
            return tmpTextTakeItem.text;
        }
    }
}


