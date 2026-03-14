using System;
using System.Collections;
using Scripts.TextScripts;
using TMPro;
using UnityEngine;

namespace Scripts.DialogueSystem.DialogueWithSalerScripts
{
    public class DialogueWithSaler : DisableAndEnableMovementAndCursorController
    {
        [SerializeField] Rigidbody rbPlayer;

        [SerializeField] TypingText typingText;
        
        [Header("Dialogue Window")]
        [SerializeField] GameObject dialogueWindow;
        [SerializeField] TMP_Text namePerson;
        [SerializeField] public TMP_Text dialogueText;

        [SerializeField] private ChoiseAnswersController choiseAnswers;

        internal bool isStartDialogue = false;
        int currentDialogueIndex = 1;

        /*private (string, Action) GetCurrentDialogue(string namePeson, int currentDialogue)
            => currentDialogue switch 
            {
                1 => ("SALER: ", FirstDialogue),
                2 => ("SALER: ", SecondDialogue),
                3 => ("SALER: ", ThirdDialogueStageFirst),
                4 => ("SALER: ", FourthDialogue),
                5 => ("SALER: ", FifthDialogue),
                6 => ("SALER: ", SixthDialogue),
                7 => ("SALER: ", SeventhDialogue),
            };*/

        public void StartDialogue()
        {
            rbPlayer.isKinematic = true;

            isStartDialogue = true;
            dialogueWindow.SetActive(true);

            //GetCurrentDialogue(namePerson.text, currentDialogueIndex);

            switch (currentDialogueIndex)
            {
                case 1:
                    FirstDialogue();
                    break;
                case 2:
                    SecondDialogue();
                    break;
                case 3:
                    ThirdDialogueStageFirst();
                    break;

                case 4:
                    FourthDialogue();
                    break;

                case 5:
                    FifthDialogue();
                    break;

                case 6:
                    SixthDialogue();
                    break;

                case 7:
                    SeventhDialogue();
                    break;
            }
        }

        public void FirstDialogue()
        {
            isDialogueWithSalerActive = true;

            DisableMovementAndShowCursor();
            DisableButtonsForAnswers();

            namePerson.text = "SALER:";
            dialogueText.text = "Здравствуй покупатель! Не ожидал что кто-то сюда приедет, в такое захолустье";
            
            typingText.UpdateText();
            StartCoroutine(choiseAnswers.ChoiseFirstAnswerCoroutine());
        }

        public void SecondDialogue()
        {
            currentDialogueIndex = 2;

            isDialogueWithSalerActive = true;

            DisableMovementAndShowCursor();
            DisableButtonsForAnswers();

            namePerson.text = "SALER:";
            dialogueText.text = "Ну в прямом, здесь месяц назад начали происходить странные вещи в лесу, уже у всех это на слуху, даже полиция отказывается выяснять что здесь случилось";
            
            typingText.UpdateText();
            StartCoroutine(choiseAnswers.ChoiseSecondAnswerCoroutine());
        }

        public void ThirdDialogueStageFirst()
        {
            currentDialogueIndex = 3;

            isDialogueWithSalerActive = true;

            DisableMovementAndShowCursor();
            DisableButtonsForAnswers();

            namePerson.text = "SALER:";
            dialogueText.text = "Нууууу, это долгая история, ты просто знай, я тебя предупредил, а ты уже сам решай идти ли тебе туда или нет";

            typingText.UpdateText();

            StartCoroutine(ThirdDialogueStageSecond());
        }

        public IEnumerator ThirdDialogueStageSecond() 
        {
            yield return new WaitForSeconds(6);
            dialogueText.text = "хотя знаешь я могу тебе рассказать почему я тут до сих пор работаю";
            typingText.UpdateText();

            StartCoroutine(ThirdDialogueStageThird());
        }

        public IEnumerator ThirdDialogueStageThird()
        {
            yield return new WaitForSeconds(4);
            dialogueText.text = "но с тебя денюжки дружок";
            typingText.UpdateText();

            StartCoroutine(choiseAnswers.ChoiseThirdAnswerCoroutine());
        }

        public void FourthDialogue() 
        {
            currentDialogueIndex = 4;

            isDialogueWithSalerActive = true;

            DisableMovementAndShowCursor();
            DisableButtonsForAnswers();

            namePerson.text = "SALER:";
            dialogueText.text = "Не мало.";

            typingText.UpdateText();

            StartCoroutine(choiseAnswers.ChoiseFourthAnswerCoroutine());
        }

        public void FifthDialogue() 
        {
            currentDialogueIndex = 5;

            isDialogueWithSalerActive = true;

            DisableMovementAndShowCursor();
            DisableButtonsForAnswers();

            namePerson.text = "SALER:";
            dialogueText.text = "Нууу эм пятихатку давай и расскажу";

            typingText.UpdateText();

            StartCoroutine(choiseAnswers.ChoiseFifthAnswerCoroutine());
        }

        public void SixthDialogue() 
        {
            currentDialogueIndex = 6;

            isDialogueWithSalerActive = true;

            DisableMovementAndShowCursor();
            DisableButtonsForAnswers();

            namePerson.text = "SALER:";
            dialogueText.text = "Ну и все тогда, давай выкладывай все что взял и оплачивай";

            typingText.UpdateText();

            StartCoroutine(choiseAnswers.ChoiseSixthAnswerCoroutine());
        }

        public void SeventhDialogue()
        {
            currentDialogueIndex = 7;

            isDialogueWithSalerActive = true;

            DisableMovementAndShowCursor();
            DisableButtonsForAnswers();

            namePerson.text = "SALER:";
            dialogueText.text = "Благодарю";

            typingText.UpdateText();

            StartCoroutine(choiseAnswers.StopAllDialogues());
        }

        public void StopDialogue()
        {
            dialogueWindow.SetActive(false);
            
            isStartDialogue = false;
        }

        public IEnumerator StopDialogueCoroutine()
        {
            namePerson.text = "SALER:";
            dialogueText.text = "Уже уходишь? ну ладно...";
            
            typingText.UpdateText();

            if (dialogueWindow.activeSelf == true)
            {
                yield return new WaitForSeconds(2);
                StopDialogue();
            }
        }

        public void DisableButtonsForAnswers() 
        {
            for (int i = 0; i < currentDialogueIndex; i++) 
            {
                switch (currentDialogueIndex)
                {
                    case 1: case 2:
                        choiseAnswers.windowChoiseAnswer.SetActive(false);
                        choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                        break;

                    case 3:
                        choiseAnswers.windowChoiseAnswer.SetActive(false);

                        choiseAnswers.answersButtons[currentDialogueIndex - 3].gameObject.SetActive(false);

                        //choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                        //choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                        break;

                    case 4:
                        choiseAnswers.windowChoiseAnswer.SetActive(false);

                        choiseAnswers.answersButtons[currentDialogueIndex - 2].gameObject.SetActive(false);

                        /*choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[2].gameObject.SetActive(false);*/
                        break;

                    case 5:
                        choiseAnswers.windowChoiseAnswer.SetActive(false);

                        choiseAnswers.answersButtons[currentDialogueIndex - 1].gameObject.SetActive(false);
                        /*choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[2].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[3].gameObject.SetActive(false);*/
                        break;

                    case 6:
                        choiseAnswers.windowChoiseAnswer.SetActive(false);

                        choiseAnswers.answersButtons[currentDialogueIndex].gameObject.SetActive(false);

                        /*choiseAnswers.answersButtons[0].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[1].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[2].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[3].gameObject.SetActive(false);
                        choiseAnswers.answersButtons[4].gameObject.SetActive(false);*/
                        break;

                    case 7:
                        choiseAnswers.windowChoiseAnswer.SetActive(false);
                        break;
                }
            }
        }

            
    }
}
