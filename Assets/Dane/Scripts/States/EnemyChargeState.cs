using UnityEngine;

namespace DaneF
{
    public class EnemyChargeState : States
    {
        public EnemyChargeState(StateMachine m) : base(m)
        {
            machine = m;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            machine.enemy.AnimateRush();
            machine.enemy.StartCharge();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Charge State");
            machine.enemy.lookAtPlayer();
            if (elapsedTime > 1.11f && elapsedTime < 1.41f)
            {
                machine.enemy.bossMoveSpeed = 7.0f;
                machine.enemy.chasePlayer();
            }

            if (elapsedTime > 3.08f)
            {
                machine.ChangeState(new EnemyIdleState(machine));
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            machine.enemy.bossMoveSpeed = machine.enemy.maxSpeed;
        }

    }
}
