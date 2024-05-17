namespace Simple.DesignPattern
{
    public class StateController
    {
        private IState _currentState;

        public void ChangeState(IState state)
        {
            _currentState?.OnExit();
            _currentState = state;
            _currentState?.OnEnter();
        }

        // Be called in Update() of Mono
        public void OnUpdate()
        {
            _currentState?.OnUpdate();
        }
    }
}
