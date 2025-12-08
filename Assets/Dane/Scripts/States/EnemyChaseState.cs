using UnityEngine;

namespace DaneF
{
    public class EnemyChaseState : States
    {
        public EnemyChaseState(StateMachine m) : base(m)
        {
            machine = m;
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Chase");
            machine.enemy.chasePlayer();
            machine.enemy.lookAtPlayer();
            if (machine.enemy.playerDistance <= 15.0f && elapsedTime > 0.8f) 
            {
                machine.ChangeState(new EnemyIdleState(machine));
            }
            if (machine.enemy.playerDistance > 25.0f) 
            {
                machine.ChangeState(new EnemyIdleState(machine));
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
