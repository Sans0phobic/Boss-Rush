using System.Collections;
using UnityEngine;

namespace DaneF
{
    public class Charge : MonoBehaviour
    {
        BoxCollider boxcol;
        void Start()
        {
            boxcol = GetComponent<BoxCollider>();
            boxcol.size = new Vector3(0.1f, 0.1f, 0.1f);
        }

        public void FuncCharge() 
        {
            StartCoroutine(ChargeTiming());
        }

        IEnumerator ChargeTiming() 
        {
            boxcol.size = new Vector3(1.0f, 1.0f, 1.0f);
            yield return new WaitForSeconds(3.0f);
            boxcol.size = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}