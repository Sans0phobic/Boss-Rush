using UnityEngine;

namespace DaneF
{
    public class EnemyIdleState : States
    {
        public EnemyIdleState(StateMachine m) : base(m)
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
            Debug.Log("Idle State | " + elapsedTime);

            if (elapsedTime >= (2.5f - machine.enemy.phase))
            {
                if (machine.enemy.playerDistance <= 8.0f)
                {
                    if (elapsedTime >= (7.0f - machine.enemy.phase))
                    {
                        machine.ChangeState(new EnemyShockwaveState(machine));
                    }
                }
                //Boss should CLAW (technically bite) at 15m
                if (machine.enemy.playerDistance > 8.0f && machine.enemy.playerDistance <= 15.0f)
                {
                    machine.ChangeState(new EnemySwipeState(machine));
                }
                //Boss should CHASE at 15 - 25m
                if (machine.enemy.playerDistance > 15.0f && machine.enemy.playerDistance <= 25.0f)
                {
                    machine.ChangeState(new EnemyChaseState(machine));
                }
                //Boss should fire LASER in phase 1, or fire LASER/CHARGE at 25m in phase 2
                if (machine.enemy.playerDistance > 25.0f && machine.enemy.phase == 0.0f)
                {
                    machine.ChangeState(new EnemyLaserState(machine));
                }
                else 
                {
                    machine.enemy.randomNumber(); //randomly swaps rng between 0 & 1

                    if (machine.enemy.rng == 0)
                        machine.ChangeState(new EnemyLaserState(machine));
                    if (machine.enemy.rng == 1)
                        machine.ChangeState(new EnemyChargeState(machine));
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
