using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] Transform playerPosition;

    private BaseState currentState;

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeState(BaseState baseState) 
    {
        if (currentState != null) 
        {
            currentState.DestroyState();
        }

        currentState = baseState;

        if (currentState != null) 
        {
            currentState.stateMachine = this;
            currentState.PrepareState();
        }
    }
}
