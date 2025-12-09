using System.Collections;
using UnityEngine;

namespace DaneF
{
    public class BoxColDisable : MonoBehaviour
    {
        private BoxCollider col;
        void Start()
        {
            col = GetComponent<BoxCollider>();
            DisableCollision();
        }

        public void DisableCollision() 
        {
            col.size = new Vector3(0.1f, 0.1f, 0.1f);
            col.enabled = false;
        }

        public void EnableCollision() 
        {
            StartCoroutine(RoarTiming());
            Debug.Log("Roar Collision enabled");
        }

        IEnumerator RoarTiming() 
        {
            yield return new WaitForSeconds(1);
            col.enabled = true;
            col.size = new Vector3(1.0f, 1.0f, 1.0f);
            yield return new WaitForSeconds(0.2f);
            DisableCollision();
        }
    }
}