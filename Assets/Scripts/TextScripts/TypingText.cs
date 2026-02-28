using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts.TextScripts
{
    public class TypingText : MonoBehaviour
    {
        [SerializeField] private TMP_Text dialogueText;
        [SerializeField] private float speedTyping = 0.05f;

        internal string isFullText;
        public bool isTyping = false;
        bool isCoroutineStopping = false;

        public void UpdateText()
        {
            isFullText = dialogueText.text;
            dialogueText.text = "";

            isTyping = true;
            StartCoroutine(TypingTextCoroutine());
        }

        public IEnumerator TypingTextCoroutine()
        {
            for (int i = 0; i < isFullText.Length && isCoroutineStopping == false; i++)
            {
                dialogueText.text += isFullText[i];
                yield return new WaitForSeconds(speedTyping);
            }

            isTyping = false;
            Debug.Log("Печать закончилась");

        }
        


    }
}
