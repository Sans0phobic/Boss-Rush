using System.Collections;
using UnityEngine;

namespace DaneF
{
    public class UltShockwave : MonoBehaviour
    {
        BoxCollider UltShockBoxCol;
        void Start()
        {
            UltShockBoxCol = GetComponent<BoxCollider>();
            UltShockBoxCol.size = new Vector3(0.1f, 0.1f, 0.1f);
        }

        public void FuncUltShock() 
        {
            StartCoroutine(UltShockTiming());
        }

        IEnumerator UltShockTiming() 
        {
            yield return new WaitForSeconds(0.8f);
            UltShockBoxCol.size = new Vector3(1.0f, 1.0f, 1.0f);
            yield return new WaitForSeconds(0.2f);
            UltShockBoxCol.size = new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}