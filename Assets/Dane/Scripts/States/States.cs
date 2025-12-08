using UnityEngine;

namespace DaneF
{
    public class States
    {
        public StateMachine machine;
        public float elapsedTime; //Switch with accessors & mutators

        public States(StateMachine m) 
        {
            machine = m;
        }

        public virtual void OnEnter() 
        {
            Debug.Log("Entered State");
        }

        public virtual void OnUpdate() 
        {
            elapsedTime += Time.deltaTime;
        }

        public virtual void OnExit() 
        {
            Debug.Log("Exited State");
        }

    }
}
