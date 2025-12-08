using UnityEngine;

namespace DaneF
{
    public class EnemyFireState : States
    {
        public EnemyFireState(StateMachine m) : base(m)
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
            Debug.Log("UltimateState");
            if (elapsedTime > 1.32f)
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
