using UnityEngine;

namespace Scripts.DialogueSystem.DialogueWithSalerScripts
{
    public class RangeInteraction : MonoBehaviour
    {
        [SerializeField] DialogueWithSaler dialogue;

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                dialogue.StopDialogue();
            }
        }
    }
}
