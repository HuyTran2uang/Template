public class StateMachine<T>
{
    private T _owner;
    private State<T> _currentState;
    private State<T> _previousState;
    private State<T> _globalState;

    public StateMachine(T owner)
    {
        _owner = owner;
    }

    public void ChangeState(State<T> newState)
    {
        _previousState = _currentState;
        _currentState?.ExitState(_owner);
        _currentState = newState;
        _currentState?.EnterState(_owner);
    }

    public void Update()
    {
        _globalState?.ExecuteState(_owner);
        _currentState?.ExecuteState(_owner);
    }

    public void RevertToPreviousState()
    {
        ChangeState(_previousState);
    }

    public void SetGlobalState(State<T> state)
    {
        _globalState = state;
        _globalState?.EnterState(_owner);
    }
}

public abstract class State<T>
{
    public abstract void EnterState(T owner);
    public abstract void ExecuteState(T owner);
    public abstract void ExitState(T owner);
}
