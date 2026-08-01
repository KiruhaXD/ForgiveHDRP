using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using _Project.Scripts.CarScripts;

namespace _Project.Scripts
{
    public class TransitionsController : MonoBehaviour
    {
        [SerializeField] Image beginTransitionWindow;

        [Header("References From Other Classes")]
        [SerializeField] TeleportCar teleportCar;

        int timeBeforeOnWindowTransition = 3;
        int timeBeforeChangeAlphaValueForBeginWindow = 2;

        float timerForBeginTransition = 15f;

        private void Awake()
        {
            // on when need transition in start game
            //ChangeAlphaValueForBeginWindow();
        }

        public void TransitionTeleportCar()
        {
            StartCoroutine(TeleportCarCoroutine());

            Debug.Log("transition active");
        }

        IEnumerator TeleportCarCoroutine()
        {
            yield return new WaitForSeconds(timeBeforeOnWindowTransition);
            beginTransitionWindow.gameObject.SetActive(true);

            teleportCar.TeleportToPointOldLocation();

            yield return new WaitForSeconds(timeBeforeChangeAlphaValueForBeginWindow);
            ChangeAlphaValueForBeginWindowToWhite();

            // restart change alpha value
            yield return new WaitForSeconds(timerForBeginTransition);
            beginTransitionWindow.gameObject.SetActive(false);
            ChangeAlphaValueForBeginWindowToBlack();
        }

        public IEnumerator DrivingToNewLocationCoroutine() 
        {
            yield return new WaitForSeconds(timeBeforeOnWindowTransition);
            beginTransitionWindow.gameObject.SetActive(true);

            teleportCar.TeleportToNewLocation();

            yield return new WaitForSeconds(timeBeforeChangeAlphaValueForBeginWindow);
            ChangeAlphaValueForBeginWindowToWhite();


            // restart change alpha value
            yield return new WaitForSeconds(2f);
            beginTransitionWindow.gameObject.SetActive(false);
            ChangeAlphaValueForBeginWindowToBlack();
        }

        public void ChangeAlphaValueForBeginWindowToWhite() => beginTransitionWindow.DOColor(new Color(0, 0, 0, 0), timerForBeginTransition);
        public void ChangeAlphaValueForBeginWindowToBlack() => beginTransitionWindow.DOColor(new Color(0, 0, 0, 255), .1f);
    }
}