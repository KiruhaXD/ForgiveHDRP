using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.InteractScripts
{
    public class WheelInteract : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForWheelMission;
        [SerializeField] GameObject interfaceMissionForWheel;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
    
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with wheel"); // active toggle in a notepad and disable mission
                toggleInNotepadForWheelMission.isOn = true;
                interfaceMissionForWheel.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a wheel";
            return tmpTextTakeItem.text;
        }
    }
}


