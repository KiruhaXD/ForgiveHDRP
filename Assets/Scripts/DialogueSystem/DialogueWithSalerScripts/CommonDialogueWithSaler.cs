using Scripts;
using Scripts.DialogueSystem.DialogueWithSalerScripts;
using Scripts.TextScripts;
using TMPro;
using UnityEngine;

public class CommonDialogueWithSaler : MonoBehaviour
{
    protected void CurrentDialogue(DisableAndEnableMovementAndCursorController disableAndEnableMovementAndCursorController,
ChoiseAnswersController choiseAnswers, int currentDialogueIndex, TypingText typingText, string namePerson, TMP_Text tmpNamePerson, string dialogueText, TMP_Text tmpDialogue)
    {
        disableAndEnableMovementAndCursorController.isDialogueWithSalerActive = true;
        disableAndEnableMovementAndCursorController.DisableMovementAndShowCursor();

        DisableButtonsForAnswers(choiseAnswers, currentDialogueIndex);

        tmpNamePerson.text = namePerson;
        tmpDialogue.text = dialogueText;

        typingText.UpdateText();
    }

    public void DisableButtonsForAnswers(ChoiseAnswersController choiseAnswers, int currentDialogueIndex)
    {
        for (int i = 0; i < currentDialogueIndex; i++)
        {
            switch (currentDialogueIndex)
            {
                case 1:
                    choiseAnswers.windowChoiseAnswer.SetActive(false);
                    choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                    break;

                case 2:
                    choiseAnswers.windowChoiseAnswer.SetActive(false);
                    choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                    break;

                case 3:
                    choiseAnswers.windowChoiseAnswer.SetActive(false);

                    choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                    break;

                case 4:
                    choiseAnswers.windowChoiseAnswer.SetActive(false);

                    choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[2].gameObject.SetActive(false);
                    break;

                case 5:
                    choiseAnswers.windowChoiseAnswer.SetActive(false);

                    choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[2].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[3].gameObject.SetActive(false);
                    break;

                case 6:
                    choiseAnswers.windowChoiseAnswer.SetActive(false);

                    choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[2].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[3].gameObject.SetActive(false);
                    choiseAnswers.answersButtons[4].gameObject.SetActive(false);
                    break;

                case 7:
                    choiseAnswers.windowChoiseAnswer.SetActive(false);
                    break;
            }
        }
    }

}
