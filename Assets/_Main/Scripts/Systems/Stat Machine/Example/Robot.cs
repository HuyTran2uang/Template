using UnityEngine;

namespace Assets._Main.Scripts.Systems.Stat_Machine.Example
{
    public class Robot : MonoBehaviour
    {
        private StateMachine<Robot> _stateMachine;

        private void Start()
        {
            _stateMachine = new StateMachine<Robot>(this);
            _stateMachine.ChangeState(new Idle());
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                ChangeState(new Move());
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangeState(new Attack());
            }
            else
            {
                ChangeState(new Idle());
            }

            _stateMachine.Update();
        }

        public void ChangeState(State<Robot> newState)
        {
            _stateMachine.ChangeState(newState);
        }
    }

    public class Idle : State<Robot>
    {
        public override void EnterState(Robot owner)
        {
            Debug.Log("EnterState" + this.GetType());
        }

        public override void ExecuteState(Robot owner)
        {
            Debug.Log("ExecuteState" + this.GetType());
        }

        public override void ExitState(Robot owner)
        {
            Debug.Log("ExitState" + this.GetType());
        }
    }

    public class Move : State<Robot>
    {
        public override void EnterState(Robot owner)
        {
            Debug.Log("EnterState" + this.GetType());
        }

        public override void ExecuteState(Robot owner)
        {
            Debug.Log("ExecuteState" + this.GetType());
        }

        public override void ExitState(Robot owner)
        {
            Debug.Log("ExitState" + this.GetType());
        }
    }

    public class Attack : State<Robot>
    {
        public override void EnterState(Robot owner)
        {
            Debug.Log("EnterState" + this.GetType());
        }

        public override void ExecuteState(Robot owner)
        {
            Debug.Log("ExecuteState" + this.GetType());
        }

        public override void ExitState(Robot owner)
        {
            Debug.Log("ExitState" + this.GetType());
        }
    }
}
