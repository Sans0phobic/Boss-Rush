using UnityEngine;

namespace DaneF
{
    public class EnemyDeathState : States
    {
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
                machine.enemy.isDead = true;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
