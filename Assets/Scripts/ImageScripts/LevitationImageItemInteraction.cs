using UnityEngine;

namespace Scripts.ImageScripts
{
    public class LevitationImageItemInteraction : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float hoverHeight = 0.1f;
        [SerializeField] float hoverForce = 1f;

        private void FixedUpdate()
        {
            LevitationImage();
        }

        public void LevitationImage()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, hoverHeight))
            {
                float distanceRatio = 1f - (hit.distance / hoverHeight);
                Vector3 liftForce = Vector3.up * hoverForce * distanceRatio;
                rb.AddForce(liftForce, ForceMode.Impulse);
            }
        }
    }
}
