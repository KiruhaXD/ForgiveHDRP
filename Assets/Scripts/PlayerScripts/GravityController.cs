using UnityEngine;

namespace Scripts.PlayerScripts
{
    public class GravityController : MonoBehaviour
    {
        [SerializeField] CharacterController characterController;

        [SerializeField] Transform groundCheck;
        [SerializeField] LayerMask groundMask;
        [SerializeField] float groundDistance = 0.4f;

        protected float Gravity = -9.81f;

        protected bool IsGrounded;
        protected Vector3 Velocity;

        public void CheckGravity()
        {
            IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (IsGrounded && Velocity.y < 0)
                Velocity.y = -2f;

            Velocity.y += Gravity * Time.deltaTime;

            characterController.Move(Velocity * Time.deltaTime);
        }


    }
}
