using System;
using System.Collections;
using Scripts.TextScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.DialogueSystem.DialogueWithSalerScripts
{
    public class DialogueWithSaler : CommonDialogueWithSaler
    {
        [Header("References")]
        [SerializeField] DisableAndEnableMovementAndCursorController disableAndEnableMovementAndCursorController;
        [SerializeField] Rigidbody rbPlayer;
        [SerializeField] TypingText typingText;
        [SerializeField] Image imageInteract;

        
        [Header("Dialogue Window")]
        [SerializeField] GameObject dialogueWindow;
        [SerializeField] TMP_Text namePerson;
        [SerializeField] public TMP_Text dialogueText;

        [SerializeField] private ChoiseAnswersController choiseAnswers;

        internal bool isStartDialogue = false;
        public static int currentDialogueIndex = 1;

        // диалог начинается очень странно

        public void StartDialogue()
        {
            rbPlayer.isKinematic = true;

            imageInteract.gameObject.SetActive(false);

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
            currentDialogueIndex = 1;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
    namePerson, "Здравствуй покупатель! Не ожидал что кто-то сюда приедет, в такое захолустье", dialogueText);

            StartCoroutine(choiseAnswers.ChoiseFirstAnswerCoroutine());

            SaveCurrentDialogue(1);
        }

        public void SecondDialogue()
        {
            currentDialogueIndex = 2;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
    namePerson, "Ну в прямом, здесь месяц назад начали происходить странные вещи в лесу, уже у всех это на слуху, даже полиция отказывается выяснять что здесь случилось", 
    dialogueText);

            StartCoroutine(choiseAnswers.ChoiseSecondAnswerCoroutine());

            SaveCurrentDialogue(2);
        }

        public void ThirdDialogueStageFirst()
        {
            currentDialogueIndex = 3;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
                namePerson, "Нууууу, это долгая история, ты просто знай, я тебя предупредил, а ты уже сам решай идти ли тебе туда или нет",
                dialogueText);

            StartCoroutine(ThirdDialogueStageSecond());

            SaveCurrentDialogue(3);
        }

        public IEnumerator ThirdDialogueStageSecond() 
        {
            yield return new WaitForSeconds(6);

            currentDialogueIndex = 3;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
                namePerson, "хотя знаешь я могу тебе рассказать почему я тут до сих пор работаю",
                dialogueText);

            StartCoroutine(ThirdDialogueStageThird());

            SaveCurrentDialogue(3);
        }

        public IEnumerator ThirdDialogueStageThird()
        {
            yield return new WaitForSeconds(4);

            currentDialogueIndex = 3;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
                namePerson, "но с тебя денюжки дружок",
                dialogueText);

            StartCoroutine(choiseAnswers.ChoiseThirdAnswerCoroutine());

            SaveCurrentDialogue(3);
        }

        public void FourthDialogue() 
        {
            currentDialogueIndex = 4;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
                            namePerson, "Не мало.",
                            dialogueText);

            StartCoroutine(choiseAnswers.ChoiseFourthAnswerCoroutine());

            SaveCurrentDialogue(4);
        }

        public void FifthDialogue() 
        {
            currentDialogueIndex = 5;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
                            namePerson, "Нууу эм пятихатку давай и расскажу",
                            dialogueText);

            StartCoroutine(choiseAnswers.ChoiseFifthAnswerCoroutine());

            SaveCurrentDialogue(5);
        }

        public void SixthDialogue() 
        {
            currentDialogueIndex = 6;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
                            namePerson, "Ну и все тогда, давай выкладывай все что взял и оплачивай",
                            dialogueText);

            StartCoroutine(choiseAnswers.ChoiseSixthAnswerCoroutine());

            SaveCurrentDialogue(6);
        }

        public void SeventhDialogue()
        {
            currentDialogueIndex = 7;

            CurrentDialogue(disableAndEnableMovementAndCursorController, choiseAnswers, currentDialogueIndex, typingText, "SALER: ",
                            namePerson, "Благодарю",
                            dialogueText);

            StartCoroutine(choiseAnswers.StopAllDialogues());

            SaveCurrentDialogue(7);
        }

        public void StopDialogue()
        {
            dialogueWindow.SetActive(false);
            
            isStartDialogue = false;

            disableAndEnableMovementAndCursorController.EnableMovementAndHideCursor();
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
