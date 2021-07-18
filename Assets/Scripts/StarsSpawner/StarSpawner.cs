using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Star.Spawner
{
    public class StarSpawner : MonoBehaviour
    {
        public Actions _actions;
        public GameObject _star;

        public GameObject[] _Points = new GameObject[2];

        public RuningState _StateRuning;
        public SpawnState _StateSpawn;
        public StateMachine _StateMachine;

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
        }

        public void Spawn()
        {
            Instantiate(_star, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}