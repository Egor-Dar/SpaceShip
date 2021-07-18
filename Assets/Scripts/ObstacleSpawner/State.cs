namespace Obstacle.Spawner
{
    public class State
    {
        protected ObstacleSpawner _ObstacleSpawner;
        protected StateMachine _stateMachine;

        protected State(ObstacleSpawner _ObstacleSpawner, StateMachine _stateMachine)
        {
            this._ObstacleSpawner = _ObstacleSpawner;
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