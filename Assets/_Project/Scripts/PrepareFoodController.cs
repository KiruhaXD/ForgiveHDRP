using System.Collections;
using _Project.Scripts.MissionsScripts;
using UnityEngine;

public class PrepareFoodController : MonoBehaviour
{
    [SerializeField] ShowMissionsManager missionManager;

    int timerPrepareFood = 2; // two seconds

    private void Update()
    {
        if (Input.GetMouseButton(3) && missionManager.isHasPrepareFood == true) 
        {
            // сделать анимацию готовки еды

            StartCoroutine(ShowMissionAfterPrepareFoodCoroutine());
        }
    }

    IEnumerator ShowMissionAfterPrepareFoodCoroutine() 
    {
        yield return new WaitForSeconds(timerPrepareFood);
        missionManager.ShowMissionPutSleepingBag();
    }
}
