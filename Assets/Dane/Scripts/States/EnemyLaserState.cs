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
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("Laser");
        }

        public override void OnExit()
        {
            base.OnExit();
        }

    }
}
