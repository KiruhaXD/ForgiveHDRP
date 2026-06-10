using _Project.Scripts.DialogueSystem.DialogueWithSalerScripts;
using UnityEngine;

namespace _ProjectScripts.DialogueSystem.DialogueWithSalerScripts
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
