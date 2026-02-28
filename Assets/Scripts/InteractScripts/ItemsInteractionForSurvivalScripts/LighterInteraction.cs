using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class LighterInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForLighterMission;
        //[SerializeField] GameObject interfaceMissionForLighter;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a lighter"); // active toggle in a notepad and disable mission
                toggleInNotepadForLighterMission.isOn = true;
                //interfaceMissionForLighter.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a lighter";
            return tmpTextTakeItem.text;
        }
    }
}


