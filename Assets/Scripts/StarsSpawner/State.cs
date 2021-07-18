using Star.Spawner;

namespace Star.Spawner
{
    public class State
    {
        protected StarSpawner _starSpawner;
        protected StateMachine _stateMachine;

        protected State(StarSpawner _starSpawner, StateMachine _stateMachine)
        {
            this._starSpawner = _starSpawner;
            this._stateMachine = _stateMachine;
        }

        public virtual void Enter()
        {
        }
        public virtual void LogicUpdate()
        {

        }
        public virtual void Exit()
        {

        }
    }
}