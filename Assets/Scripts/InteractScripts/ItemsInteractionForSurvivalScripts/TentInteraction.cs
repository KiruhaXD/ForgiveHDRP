using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class TentInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForTentMission;
        //[SerializeField] GameObject interfaceMissionForTent;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a tent"); // active toggle in a notepad and disable mission
                toggleInNotepadForTentMission.isOn = true;
                //interfaceMissionForTent.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a tent";
            return tmpTextTakeItem.text;
        }
    }
}


