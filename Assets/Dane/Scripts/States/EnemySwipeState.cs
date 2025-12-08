using UnityEngine;

namespace DaneF
{
    public class EnemySwipeState : States
    {
        public EnemySwipeState(StateMachine m) : base(m)
        {
            machine = m;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            machine.enemy.AnimateBite();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Swipe State");
            machine.enemy.lookAtPlayer();
            if (elapsedTime > 1.1f) 
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
