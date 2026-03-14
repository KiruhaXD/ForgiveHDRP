using Scripts.InterfaceScripts;
using UnityEngine;

namespace Scripts.PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] CrouchController crouchController;
        [SerializeField] StaminaSliderController staminaSliderController;
        //[SerializeField] TerrainLayersController terrainLayersController;
        [SerializeField] AudioManager audioManager;
        [SerializeField] DrivingPlayer drivingPlayer;

        [SerializeField] CharacterController characterController;
        [SerializeField] float speedWalk = 2f;
        [SerializeField] float speedRun = 3f;

        [SerializeField] Animator animator;

        internal Vector3 MovePlayer;

        internal float Horizontal;
        internal float Vertical;

        internal float SmoothTime = 0.15f;
        internal bool IsKeyPressLeftShift = false;

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
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift)) // is working!!!
            {
                IsKeyPressLeftShift = false; // Stop running
            }
        }

        public void Walk()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");

            MovePlayer = transform.TransformDirection(Horizontal, 0f, Vertical);
            
            characterController.Move(MovePlayer * speedWalk * Time.deltaTime);

            AnimationForWalk();
        }

        public void Run()
        {
            characterController.Move(MovePlayer * speedRun * Time.deltaTime);
            animator.SetFloat("y", 1.5f, SmoothTime, Time.deltaTime);

            staminaSliderController.DecreasedStamina();

            audioManager.PlayAudioForGrassRun();
        }
        
        public void AnimationForWalk()
        {
            if (Vertical != 0) 
            {
                if (Vertical > 0)
                {
                    animator.SetFloat("y", Vertical = 1f, SmoothTime, Time.deltaTime);
                }

                else
                    animator.SetFloat("y", Vertical = -1f, SmoothTime, Time.deltaTime);

                //terrainLayersController.RayCheckLayer();
                audioManager.PlayAudioForGrassWalk();
            }

            else
                animator.SetFloat("y", 0f, SmoothTime, Time.deltaTime);

            if (Horizontal != 0)
            {
                if (Horizontal > 0)
                {
                    animator.SetFloat("x", Horizontal = 1f, SmoothTime, Time.deltaTime);
                }

                else
                    animator.SetFloat("x", Horizontal = -1f, SmoothTime, Time.deltaTime);

                //terrainLayersController.RayCheckLayer();
                audioManager.PlayAudioForGrassWalk();
            }

            else
                animator.SetFloat("x", 0f, SmoothTime, Time.deltaTime);
        }
    }

}
