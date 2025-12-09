using System.Buffers;
using System.Collections;
using UnityEngine;

namespace DaneF
{
    public class Laser : MonoBehaviour
    {
        private MeshRenderer mesh;
        private CapsuleCollider caps;

        void Start()
        {
            mesh = GetComponent<MeshRenderer>();
            caps = GetComponent<CapsuleCollider>();
            mesh.enabled = false;
            caps.height = 1;
        }

        public void SubLaser()
        {
            StartCoroutine(LaserCounterA());
        }

        IEnumerator LaserCounterA()
        {
            yield return new WaitForSeconds(0.8f);
            mesh.enabled = true;
            caps.height = 2;
            yield return new WaitForSeconds(1.1f);
            mesh.enabled = false;
            caps.height = 1;
        }
    }
}