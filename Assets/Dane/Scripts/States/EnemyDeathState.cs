using UnityEngine;

namespace DaneF
{
    public class EnemyDeathState : States
    {
        GameManager gameManager;
        public EnemyDeathState(StateMachine m) : base(m)
        {
            machine = m;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            machine.enemy.AnimateDie();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Death State");
            if (elapsedTime >= 5.0f) 
            {
                gameManager.GoToNextLevel();
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
