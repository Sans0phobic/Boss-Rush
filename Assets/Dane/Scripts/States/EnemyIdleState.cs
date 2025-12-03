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
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
