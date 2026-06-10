public class BaseState
{
    public StateMachine stateMachine;

    public virtual void PrepareState() { }
    public virtual void UpdateState() { }
    public virtual void DestroyState() { }
}
