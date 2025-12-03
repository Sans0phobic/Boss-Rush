using brolive;
using UnityEngine;

namespace DaneF
{
    public class StateMachine
    {
        States currentState;
        public EnemyTest enemy; //mutator & accessor later

        public StateMachine(EnemyTest enemy) 
        {
            this.enemy = enemy;
        }

        public void Update() 
        {
            currentState.OnUpdate();
        }

        public void ChangeState(States newState) 
        {
            if(currentState != null)
                currentState.OnExit();

            currentState = newState;

            currentState.OnEnter();
        }
    }
}