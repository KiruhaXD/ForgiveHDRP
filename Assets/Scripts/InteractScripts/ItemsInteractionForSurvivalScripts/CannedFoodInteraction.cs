using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class CannedFoodInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForCannedFoodMission;
        //[SerializeField] GameObject interfaceMissionForCannedFood;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a canned food"); // active toggle in a notepad and disable mission
                toggleInNotepadForCannedFoodMission.isOn = true;
                //interfaceMissionForCannedFood.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a canned food";
            return tmpTextTakeItem.text;
        }
    }
}


