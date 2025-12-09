using UnityEngine;

namespace DaneF
{
    public class EnemyUltShockState : States
    {
        public EnemyUltShockState(StateMachine m) : base(m)
        {
            machine = m;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            machine.enemy.AnimateShockwave();
            machine.enemy.StartUltimateShock();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("UltShockState");
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}