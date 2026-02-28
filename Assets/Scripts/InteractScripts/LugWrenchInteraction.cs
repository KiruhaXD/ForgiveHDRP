using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Scripts.InteractScripts
{
    public class LugWrenchInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForLugWrenchMission;
        [SerializeField] GameObject interfaceMissionForLugWrench;
    
        [SerializeField] TMP_Text tmpTextTakeItem;
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a lug wrench"); // active toggle in a notepad and disable mission
                toggleInNotepadForLugWrenchMission.isOn = true;
                interfaceMissionForLugWrench.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a lug wrench";
            return tmpTextTakeItem.text;
        }
    }
}


