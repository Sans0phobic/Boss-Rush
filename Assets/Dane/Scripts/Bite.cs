using System.Collections;
using UnityEngine;

namespace DaneF
{
    public class Bite : MonoBehaviour
    {
        CapsuleCollider sphere;

        void Start()
        {
            sphere = GetComponent<CapsuleCollider>();
            sphere.radius = 0.1f;
        }

        public void FuncBite()
        {
            StartCoroutine(BiteTiming());
        }

        IEnumerator BiteTiming() 
        {
            yield return new WaitForSeconds(0.6f);
            sphere.radius = 1.1f;
            yield return new WaitForSeconds(0.2f);
            sphere.radius = 0.1f;
        }
    }
}