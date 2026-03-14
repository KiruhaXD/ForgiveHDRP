using Scripts.DialogueSystem.DialogueWithSalerScripts;
using Scripts.TextScripts;
using TMPro;
using UnityEngine;

namespace Scripts.InteractScripts
{
    public class SalerInteract : MonoBehaviour, IInteractable
    {
        [SerializeField] DialogueWithSaler dialogue;
        [SerializeField] TypingText typingText;
        
        [SerializeField] TMP_Text tmpTextTalkWithSaler;
        
        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Dialogue system
                dialogue.StartDialogue();
                
                Debug.Log("Interact with saler");
            }

        }

        public string Description()
        {
            tmpTextTalkWithSaler.text = "Talk with saler";
            return tmpTextTalkWithSaler.text;
        }
    }
}

