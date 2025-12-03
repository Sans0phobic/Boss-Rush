using UnityEngine;

namespace DaneF
{
    public class EnemyShockwaveState : States
    {
        public EnemyShockwaveState(StateMachine m) : base(m)
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
            Debug.Log("Shockwave");
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
