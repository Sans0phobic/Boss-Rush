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
            machine.enemy.AnimateIdle();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Idle State");
            if (machine.enemy.playerDistance > 10.0f)
                machine.enemy.lookAtPlayer();

            if (machine.enemy.bossHealth <= 0)
                machine.ChangeState(new EnemyDeathState(machine));

            if (elapsedTime >= (2.5f - (machine.enemy.phase/2)))
            {
                if (machine.enemy.ultimateToken)
                {
                    machine.ChangeState(new EnemyUltShockState(machine));
                }
                else
                {
                    //Boss should push the player back if they attack their leg for too long, this gets shorter over time so you're incentivized to attack the head
                    if (machine.enemy.playerDistance <= 8.0f)
                    {
                        if (elapsedTime >= (Mathf.Clamp(5.0f - (machine.enemy.phase * 2), 1.0f, 5.0f)))
                        {
                            machine.ChangeState(new EnemyShockwaveState(machine));
                        }
                    }
                    //Boss should CLAW (technically bite) at 15m
                    else if (machine.enemy.playerDistance <= 15.0f)
                    {
                        machine.ChangeState(new EnemySwipeState(machine));
                    }
                    //Boss should CHASE at 15 - 25m
                    else if (machine.enemy.playerDistance <= 25.0f)
                    {
                        machine.ChangeState(new EnemyChaseState(machine));
                    }
                    //Boss should fire LASER in phase 1, or fire LASER/CHARGE at 25m in phase 2
                    else if (machine.enemy.playerDistance > 25.0f)
                    {
                        if (machine.enemy.phase == 0.0f)
                            machine.ChangeState(new EnemyLaserState(machine));
                        else
                        {
                            machine.enemy.randomNumber(); //randomly swaps rng between 0 & 1
                            Debug.Log(machine.enemy.rng);

                            if (machine.enemy.rng == 0)
                                machine.ChangeState(new EnemyLaserState(machine));
                            if (machine.enemy.rng == 1)
                                machine.ChangeState(new EnemyChargeState(machine));
                        }
                    }
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
