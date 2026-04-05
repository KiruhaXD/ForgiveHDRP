using UnityEngine;
using UnityEngine.UI;

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