using UnityEngine;

namespace DaneF
{
    public class LaserPillar : MonoBehaviour
    {
        private float lifetime = 3.0f;

        void Update()
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
                Destroy(gameObject);
        }
    }
}