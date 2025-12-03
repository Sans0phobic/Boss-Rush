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
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
