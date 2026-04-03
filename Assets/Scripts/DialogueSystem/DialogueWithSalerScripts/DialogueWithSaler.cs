using System;
using System.Collections;
using Scripts.TextScripts;
using TMPro;
using UnityEngine;

namespace Scripts.DialogueSystem.DialogueWithSalerScripts
{
    public class DialogueWithSaler : CommonDialogueWithSaler
    {
        [Header("References")]
        [SerializeField] DisableAndEnableMovementAndCursorController disableAndEnableMovementAndCursorController;

        [SerializeField] Rigidbody rbPlayer;

        [SerializeField] TypingText typingText;
        
        [Header("Dialogue Window")]
        [SerializeField] GameObject dialogueWindow;
        [SerializeField] TMP_Text namePerson;
        [SerializeField] public TMP_Text dialogueText;

        [SerializeField] private ChoiseAnswersController choiseAnswers;

        internal bool isStartDialogue = false;
        int currentDialogueIndex = 1;

        // диалог начинается очень странно

        public void StartDialogue()
        {
            rbPlayer.isKinematic = true;

            isStartDialogue = true;
            dialogueWindow.SetActive(true);

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
            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, 1, typingText, "SALER: ",
    namePerson, "Здравствуй покупатель! Не ожидал что кто-то сюда приедет, в такое захолустье", dialogueText);

            StartCoroutine(choiseAnswers.ChoiseFirstAnswerCoroutine());
        }

        public void SecondDialogue()
        {
            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, 2, typingText, "SALER: ",
    namePerson, "Ну в прямом, здесь месяц назад начали происходить странные вещи в лесу, уже у всех это на слуху, даже полиция отказывается выяснять что здесь случилось", 
    dialogueText);

            StartCoroutine(choiseAnswers.ChoiseSecondAnswerCoroutine());
        }

        public void ThirdDialogueStageFirst()
        {
            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, 3, typingText, "SALER: ",
                namePerson, "Нууууу, это долгая история, ты просто знай, я тебя предупредил, а ты уже сам решай идти ли тебе туда или нет",
                dialogueText);

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
            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, 4, typingText, "SALER: ",
                            namePerson, "Не мало.",
                            dialogueText);

            StartCoroutine(choiseAnswers.ChoiseFourthAnswerCoroutine());
        }

        public void FifthDialogue() 
        {
            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, 5, typingText, "SALER: ",
                            namePerson, "Нууу эм пятихатку давай и расскажу",
                            dialogueText);

            StartCoroutine(choiseAnswers.ChoiseFifthAnswerCoroutine());
        }

        public void SixthDialogue() 
        {
            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, 6, typingText, "SALER: ",
                            namePerson, "Ну и все тогда, давай выкладывай все что взял и оплачивай",
                            dialogueText);

            StartCoroutine(choiseAnswers.ChoiseSixthAnswerCoroutine());
        }

        public void SeventhDialogue()
        {
            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, 7, typingText, "SALER: ",
                            namePerson, "Благодарю",
                            dialogueText);

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

            
    }
}
