using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    float smoothTime = 0.15f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ChangeAnimation(float verticalDirection, float horizontalDirection)
    {
        if (verticalDirection != 0)
        {
            if (verticalDirection > 0)
            {
                animator.SetFloat("y", verticalDirection = 1f, smoothTime, Time.deltaTime);

                if(Input.GetKey(KeyCode.LeftShift))
                    animator.SetFloat("y", 1.5f, smoothTime, Time.deltaTime);
            }

            else
                animator.SetFloat("y", verticalDirection = -1f, smoothTime, Time.deltaTime);
        }

        else
            animator.SetFloat("y", 0f, smoothTime, Time.deltaTime);

        if (horizontalDirection != 0)
        {
            if (horizontalDirection > 0)
            {
                animator.SetFloat("x", horizontalDirection = 1f, smoothTime, Time.deltaTime);
            }

            else
                animator.SetFloat("x", horizontalDirection = -1f, smoothTime, Time.deltaTime);
        }

        else
            animator.SetFloat("x", 0f, smoothTime, Time.deltaTime);
    }
}
