using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Obstacle.Spawner
{
    public class SpawnState : State
    {
        public SpawnState(ObstacleSpawner _ObstacleSpawner, StateMachine _stateMachine) : base(_ObstacleSpawner, _stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            _ObstacleSpawner.Spawn();
            Exit();
        }

        public override void Exit()
        {
            base.Exit();
            _ObstacleSpawner._StateMachine.Initialize(_ObstacleSpawner._StateRuning);
        }
    }
}