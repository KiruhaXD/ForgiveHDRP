using System.Collections;
using Scripts.TextScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.DialogueSystem.DialogueWithSalerScripts
{
    public class ChoiseAnswersController : ChoiseAnswerContollerCommon
    {
        [SerializeField] DialogueWithSaler dialogue;
        [SerializeField] DisableAndEnableMovementAndCursorController disableAndEnableMovementAndCursorController;
        [SerializeField] TypingText typingText;
        [SerializeField] public GameObject windowChoiseAnswer;
        
        [Header("Buttons for answers")]
        [SerializeField] public Button[] answersButtons;
        [SerializeField] public Button answerForExitDialogueBtn;
        
        public void FirstAnswerClickButton() => dialogue.SecondDialogue();
        
        public void SecondAnswerClickButton() => dialogue.ThirdDialogueStageFirst();

        public void ThirdAnswerClickButton() => dialogue.FourthDialogue();

        public void FourthAnswerClickButton() => dialogue.FifthDialogue();

        public void FifthAnswerClickButton() => dialogue.SixthDialogue();

        public void SixthAnswerClickButton() => dialogue.SeventhDialogue();
        
        public void StopDialogueClickButton()
        {
            StartCoroutine(dialogue.StopDialogueCoroutine());
            disableAndEnableMovementAndCursorController.EnableMovementAndHideCursor();

            disableAndEnableMovementAndCursorController.isDialogueWithSalerActive = false;

            Debug.Log("Press Exit button");
        }
        
        public IEnumerator ChoiseFirstAnswerCoroutine()
        {
            yield return new WaitForSeconds(5);
            ChoiseAnswer(windowChoiseAnswer, answersButtons, 0, answerForExitDialogueBtn);
        }
        
        public IEnumerator ChoiseSecondAnswerCoroutine()
        {
            yield return new WaitForSeconds(8);
            ChoiseAnswer(windowChoiseAnswer, answersButtons, 1, answerForExitDialogueBtn);
        }
        
        public IEnumerator ChoiseThirdAnswerCoroutine()
        {
            yield return new WaitForSeconds(3);
            ChoiseAnswer(windowChoiseAnswer, answersButtons, 2, answerForExitDialogueBtn);
        }

        public IEnumerator ChoiseFourthAnswerCoroutine() 
        {
            yield return new WaitForSeconds(2);
            ChoiseAnswer(windowChoiseAnswer, answersButtons, 3, answerForExitDialogueBtn);
        }

        public IEnumerator ChoiseFifthAnswerCoroutine() 
        {
            yield return new WaitForSeconds(4);
            ChoiseAnswer(windowChoiseAnswer, answersButtons, 4, answerForExitDialogueBtn);
        }

        public IEnumerator ChoiseSixthAnswerCoroutine() 
        {
            yield return new WaitForSeconds(4);
            ChoiseAnswer(windowChoiseAnswer, answersButtons, 5, answerForExitDialogueBtn);
        }

        public IEnumerator StopAllDialogues() 
        {
            yield return new WaitForSeconds(2);
            dialogue.StopDialogue();
            disableAndEnableMovementAndCursorController.EnableMovementAndHideCursor();

            disableAndEnableMovementAndCursorController.isDialogueWithSalerActive = false;
        }
    }
}
