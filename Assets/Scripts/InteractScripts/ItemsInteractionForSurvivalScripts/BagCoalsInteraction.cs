using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.InteractScripts.ItemsInteractionForSurvivalScripts
{
    public class BagCoalsInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] Toggle toggleInNotepadForBagCoalsMission;
        //[SerializeField] GameObject interfaceMissionForBagCoals;

        [SerializeField] TMP_Text tmpTextTakeItem;

        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Interact with a bag coals"); // active toggle in a notepad and disable mission
                toggleInNotepadForBagCoalsMission.isOn = true;
                //interfaceMissionForBagCoals.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        public string Description()
        {
            tmpTextTakeItem.text = "Take a bag coals";
            return tmpTextTakeItem.text;
        }
    }
}