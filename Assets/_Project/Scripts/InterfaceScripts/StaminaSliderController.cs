using Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.InterfaceScripts 
{
    public class StaminaSliderController : MonoCache
    {
        [SerializeField] PlayerMovement playerMovement;

        [SerializeField] public Slider sliderStamina;
        [SerializeField] float speedStaminaSlider = 1;

        internal bool endStamina = false;
        int mediumCountStaminaForJumping = 50;

        private void Start()
        {
            sliderStamina.gameObject.SetActive(false);
        }

        public override void OnTick()
        {
            CheckStaminaSlider();
        }

        public void CheckStaminaSlider()
        {
            if (sliderStamina.value < 100 && playerMovement.IsKeyPressLeftShift == false) // is working!!!
                IncreasedStamina(); // if player stay or walking

            if (sliderStamina.value == 0) // if stamina the end
                endStamina = true;

            if (sliderStamina.value == 100)
            {
                sliderStamina.gameObject.SetActive(false);
                endStamina = false;
            }
        }

        public void DecreasedStamina()
        {
            sliderStamina.gameObject.SetActive(true);
            sliderStamina.value -= speedStaminaSlider / 2f;
        }

        public void IncreasedStamina()
        {
            sliderStamina.gameObject.SetActive(true);
            sliderStamina.value += speedStaminaSlider / 4f;
        }
        public void DecreasedStaminaFromJump() => sliderStamina.value -= mediumCountStaminaForJumping;
    }
}


