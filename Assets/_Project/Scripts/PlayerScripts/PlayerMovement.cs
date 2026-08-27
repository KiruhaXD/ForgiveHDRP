using _Project.Scripts.AudioScripts;
using _Project.Scripts.InterfaceScripts;
using UnityEngine;

namespace _Project.Scripts.PlayerScripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] CrouchController crouchController;
        [SerializeField] StaminaSliderController staminaSliderController;
        //[SerializeField] TerrainLayersController terrainLayersController;
        [SerializeField] AudioManager audioManager;
        [SerializeField] DrivingPlayer drivingPlayer;
        [SerializeField] PlayerAnimation playerAnimation;

        [SerializeField] CharacterController characterController;
        [SerializeField] float speedWalk = 2f;
        [SerializeField] float speedRun = 3f;

        internal Vector3 MovePlayer;

        [HideInInspector]
        public Vector3 inputKeyboard;

        internal bool IsKeyPressLeftShift = false;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if(drivingPlayer.isInCar == false)
                CheckMovementWalkAndRun();
        }

        public void CheckMovementWalkAndRun()
        {
            if(crouchController.countPressKeyC == 0 && crouchController.crouchActive == false) // dont touch this
                Walk();
                
            IsKeyPressLeftShift = false;

            if (Input.GetKey(KeyCode.W)) // here all working!!!
            {
                if (Input.GetKey(KeyCode.LeftShift) && IsKeyPressLeftShift == false && crouchController.crouchActive == false && staminaSliderController.endStamina == false)
                {
                    audioManager.StopAudioForGrassWalk();

                    IsKeyPressLeftShift = true;
                    Run();
                }


                if (Input.GetKeyUp(KeyCode.LeftShift)) // is working!!!
                    IsKeyPressLeftShift = false; // Stop running
                
                    

            }

            // анимация ходьбы не работает!
            if (staminaSliderController.endStamina == true)
            {
                Walk();
                Debug.Log("End Stamina!");
            }

        }

        void InputKeyboard() => 
            inputKeyboard = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;


        public void Walk()
        {
            InputKeyboard();

            MovePlayer = transform.TransformDirection(inputKeyboard.x, 0f, inputKeyboard.z);

            characterController.Move(MovePlayer * speedWalk * Time.deltaTime);

            playerAnimation.ChangeAnimation(inputKeyboard.z, inputKeyboard.x);

            staminaSliderController.IncreasedStaminaWalk();

            audioManager.PlayAudioForGrassWalk();
        }

        public void Run()
        {
            characterController.Move(MovePlayer * speedRun * Time.deltaTime);

            playerAnimation.ChangeAnimation(inputKeyboard.z, inputKeyboard.x);

            staminaSliderController.DecreasedStamina();

            audioManager.PlayAudioForGrassRun();
        }
        

    }

}
