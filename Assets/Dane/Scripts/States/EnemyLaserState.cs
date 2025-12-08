using UnityEngine;

namespace DaneF
{
    public class EnemyLaserState : States
    {
        public EnemyLaserState(StateMachine m) : base(m)
        {
            machine = m;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            machine.enemy.AnimateLaser();
            machine.enemy.bossRotationSpeed = 1.5f;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Laser State");
            if (elapsedTime > 2.38f && machine.enemy.ultimateToken) 
            {
                machine.ChangeState(new EnemyFireState(machine));
            }
            if (elapsedTime > 2.9f)
            {
                machine.ChangeState(new EnemyIdleState(machine));
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            machine.enemy.bossRotationSpeed = machine.enemy.maxRotationSpeed;
        }

    }
}
