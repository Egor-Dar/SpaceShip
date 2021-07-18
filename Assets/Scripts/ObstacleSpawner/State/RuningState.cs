using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Obstacle.Spawner
{
    public class RuningState : State
    {
        public int _CurrentPoint;
        private float _SpawnDist;
        public RuningState(ObstacleSpawner _ObstacleSpawner, StateMachine _stateMachine) : base(_ObstacleSpawner, _stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            //_SpawnDist = Random.RandomRange(2.000f, 5.000f);
            _ObstacleSpawner.StartCoroutine(SpawnTime());
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_ObstacleSpawner._Points.Length == 0)
            {
                return;
            }

            if (_CurrentPoint == 0)
            {
                _ObstacleSpawner.gameObject.transform.Translate(0, -0.04f, 0);

                if (_ObstacleSpawner._Points[0].transform.position.y >= _ObstacleSpawner.transform.position.y)
                {
                    _CurrentPoint = 1;

                }

            }

            if (_CurrentPoint == 1)
            {
                _ObstacleSpawner.gameObject.transform.Translate(0, 0.04f, 0);

                if (_ObstacleSpawner._Points[1].transform.position.y <= _ObstacleSpawner.transform.position.y)
                {
                    _CurrentPoint = 0;
                }

            }

        }
        public override void Exit()
        {
            base.Exit();
            _ObstacleSpawner._StateMachine.Initialize(_ObstacleSpawner._StateSpawn);
        }

        IEnumerator SpawnTime()
        {
            if (_ObstacleSpawner._actions._HorSpeed >= 0.3f)
            {
                yield return new WaitForSeconds(Random.Range(0.000f,2.000f));
            }

            if (_ObstacleSpawner._actions._HorSpeed < 0.3f)
            {
                yield return new WaitForSeconds(Random.Range(2.0f,5.0f));
            }
            Exit();
        }
    }
}