using brolive;
using UnityEngine;

namespace DaneF
{
    public class StateMachine
    {
        States currentState;
        public BossScript enemy { get; private set; } //mutator & accessor later

        public StateMachine(BossScript enemy) 
        {
            this.enemy = enemy;
        }

        public void Update() 
        {
            currentState?.OnUpdate();
        }

        public void ChangeState(States newState) 
        {
            currentState?.OnExit();

            currentState = newState;

            currentState.OnEnter();
        }
    }
}