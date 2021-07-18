using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle.Spawner
{
    public class ObstacleSpawner : MonoBehaviour
    {
        public Actions _actions;
        public GameObject[] _Obstacles = new GameObject[3];

        public GameObject[] _Points = new GameObject[2];

        public RuningState _StateRuning;
        public SpawnState _StateSpawn;
        public StateMachine _StateMachine;
        private int _RandomObstacles;

        void Start()
        {
            _Points = GameObject.FindGameObjectsWithTag("Point");

            _StateMachine = new StateMachine();
            _StateRuning = new RuningState(this, _StateMachine);
            _StateSpawn = new SpawnState(this, _StateMachine);

            _StateMachine.Initialize(_StateRuning);

            _StateRuning._CurrentPoint = 0;
        }

        void Update()
        {

            _StateMachine._CurrentState.LogicUpdate();
            _RandomObstacles = Random.RandomRange(0, 3);
        }

        public void Spawn()
        {
            Instantiate(_Obstacles[_RandomObstacles], gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}