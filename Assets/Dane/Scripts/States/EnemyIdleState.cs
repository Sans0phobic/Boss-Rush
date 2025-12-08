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
            Debug.Log("Idle");

            if (elapsedTime >= (2.5f - machine.enemy.phase))
            {
                if (machine.enemy.playerDistance <= 8)
                {
                    if (elapsedTime >= (10.0 - machine.enemy.phase))
                    {
                        Debug.Log("EnemyShockwaveState");
                        machine.ChangeState(new EnemyShockwaveState(machine));
                    }
                }
                //Boss should CLAW (technically bite) at 15m
                if (machine.enemy.playerDistance > 8 && machine.enemy.playerDistance <= 15)
                {
                    Debug.Log("EnemySwipeState");
                    machine.enemy.countdown = 10.0f;
                }
                //Boss should CHASE at 15 - 25m
                if (machine.enemy.playerDistance > 15 && machine.enemy.playerDistance <= 25)
                {
                    Debug.Log("EnemyChaseState");
                }
                //Boss should fire LASER in phase 1, or fire LASER/CHARGE at 25m in phase 2
                if (machine.enemy.playerDistance > 25 && machine.enemy.phase == 1.0f)
                {

                }
                else 
                {
                    machine.enemy.randomNumber(); //randomly swaps rng between 0 & 1

                    if (machine.enemy.rng == 0)
                        Debug.Log("EnemyLaserState");
                    if (machine.enemy.rng == 1)
                        Debug.Log("EnemyChargeState");
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
