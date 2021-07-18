using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Star.Spawner
{
    public class StateMachine
    {
        public State _CurrentState { get; private set; }
        public void Initialize(State _startingState)
        {
            _CurrentState = _startingState;
            _startingState.Enter();
        }

        public void ChangeState(State _newState)
        {
            _CurrentState.Exit();

            _CurrentState = _newState;
            _newState.Enter();
        }
    }
}