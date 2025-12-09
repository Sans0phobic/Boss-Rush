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
            machine.enemy.StartLaser();
            machine.enemy.bossRotationSpeed = 1.5f;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Laser State");
            if (elapsedTime > 2.9f && machine.enemy.ultimateToken) 
            {
                machine.enemy.ultimateToken = false;
                machine.ChangeState(new EnemyFireState(machine));
            }
            else if (elapsedTime > 2.9f)
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
