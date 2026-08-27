using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.DialogueSystem.DialogueWithSalerScripts
{

    // скрипт отвечающий за выбор ответа(выведен как отдельный скрипт для одинаковых методов, сделано для удобства)
    public class ChoiseAnswerContollerCommon : MonoBehaviour
    {
        protected void ChoiseAnswer(GameObject windowChoise, Button[] arrayAnswersBtn,
            int indexAnswer, Button answerExitDialogueBtn)
        {
            windowChoise.SetActive(true);
            arrayAnswersBtn[indexAnswer].gameObject.SetActive(true);
            answerExitDialogueBtn.gameObject.SetActive(true);
        }
    }
}