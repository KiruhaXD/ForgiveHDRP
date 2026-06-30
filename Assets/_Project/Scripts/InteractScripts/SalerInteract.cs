using _Project.Scripts.DialogueSystem.DialogueWithSalerScripts;
using Scripts.TextScripts;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.InteractScripts
{
    public class SalerInteract : MonoBehaviour, IInteractable
    {
        [Header("Dialogue")]

        [SerializeField] DialogueWithSaler dialogue;
        [SerializeField] TypingText typingText;
        
        [SerializeField] TMP_Text tmpTextTalkWithSaler;

        private void Awake()
        {
            if (PlayerPrefs.HasKey(CommonDialogueWithSaler.CurrentDialogueIndexKey))
                DialogueWithSaler.currentDialogueIndex = CommonDialogueWithSaler.LoadCurrentDialogue(DialogueWithSaler.currentDialogueIndex);
        }

        public void Interact()
        {
            // Dialogue system
            dialogue.StartDialogue();

            Debug.Log("Interact with saler");
        }

        public string Description() 
        {
            tmpTextTalkWithSaler.text = "Talk with saler";
            return tmpTextTalkWithSaler.text;
        } 
    }
}

