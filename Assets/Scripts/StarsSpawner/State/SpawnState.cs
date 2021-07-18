using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Star.Spawner
{
    public class SpawnState : State
    {
        public SpawnState(StarSpawner _starSpawner, StateMachine _stateMachine) : base(_starSpawner, _stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            _starSpawner.Spawn();
            Exit();
        }

        public override void Exit()
        {
            base.Exit();
            _starSpawner._StateMachine.Initialize(_starSpawner._StateRuning);
        }
    }
}