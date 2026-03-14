using System.Collections;
using Scripts.TextScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.DialogueSystem.DialogueWithSalerScripts
{
    public class ChoiseAnswersController : MonoBehaviour
    {
        [SerializeField] DialogueWithSaler dialogue;
        [SerializeField] TypingText typingText;
        [SerializeField] public GameObject windowChoiseAnswer;
        
        [Header("Buttons for answers")]
        [SerializeField] public Button[] answersButtons;
        [SerializeField] public Button answerForExitDialogueBtn;
        
        public void ChoiseFirstAnswer()
        {
            windowChoiseAnswer.SetActive(true);
            answersButtons[0].gameObject.SetActive(true);
            answerForExitDialogueBtn.gameObject.SetActive(true);
        }

        public void ChoiseSecondAnswer()
        {
            windowChoiseAnswer.SetActive(true);
            answersButtons[1].gameObject.SetActive(true);
            answerForExitDialogueBtn.gameObject.SetActive(true);
        }

        public void ChoiseThirdAnswer()
        {
            windowChoiseAnswer.SetActive(true);
            answersButtons[2].gameObject.SetActive(true);
            answerForExitDialogueBtn.gameObject.SetActive(true);
        }

        public void ChoiseFourthAnswer() 
        {
            windowChoiseAnswer.SetActive(true);
            answersButtons[3].gameObject.SetActive(true);
            answerForExitDialogueBtn.gameObject.SetActive(true);
        }

        public void ChoiseFifthAnswer() 
        {
            windowChoiseAnswer.SetActive(true);
            answersButtons[4].gameObject.SetActive(true);
            answerForExitDialogueBtn.gameObject.SetActive(true);
        }

        public void ChoiseSixthAnswer() 
        {
            windowChoiseAnswer.SetActive(true);
            answersButtons[5].gameObject.SetActive(true);
            answerForExitDialogueBtn.gameObject.SetActive(true);
        }

        public void FirstAnswerClickButton() => dialogue.SecondDialogue();
        
        public void SecondAnswerClickButton() => dialogue.ThirdDialogueStageFirst();

        public void ThirdAnswerClickButton() => dialogue.FourthDialogue();

        public void FourthAnswerClickButton() => dialogue.FifthDialogue();

        public void FifthAnswerClickButton() => dialogue.SixthDialogue();

        public void SixthAnswerClickButton() => dialogue.SeventhDialogue();
        
        public void StopDialogueClickButton()
        {
            StartCoroutine(dialogue.StopDialogueCoroutine());
            dialogue.EnableMovementAndHideCursor();

            dialogue.isDialogueWithSalerActive = false;

            Debug.Log("Press Exit button");
        }
        
        public IEnumerator ChoiseFirstAnswerCoroutine()
        {
            yield return new WaitForSeconds(5);
            ChoiseFirstAnswer();   
        }
        
        public IEnumerator ChoiseSecondAnswerCoroutine()
        {
            yield return new WaitForSeconds(8);
            ChoiseSecondAnswer();
        }
        
        public IEnumerator ChoiseThirdAnswerCoroutine()
        {
            yield return new WaitForSeconds(3);
            ChoiseThirdAnswer(); 
        }

        public IEnumerator ChoiseFourthAnswerCoroutine() 
        {
            yield return new WaitForSeconds(2);
            ChoiseFourthAnswer();
        }

        public IEnumerator ChoiseFifthAnswerCoroutine() 
        {
            yield return new WaitForSeconds(4);
            ChoiseFifthAnswer();
        }

        public IEnumerator ChoiseSixthAnswerCoroutine() 
        {
            yield return new WaitForSeconds(4);
            ChoiseSixthAnswer();
        }

        public IEnumerator StopAllDialogues() 
        {
            yield return new WaitForSeconds(2);
            dialogue.StopDialogue();
            dialogue.EnableMovementAndHideCursor();

            dialogue.isDialogueWithSalerActive = false;
        }
    }
}
