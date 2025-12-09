using DG.Tweening;
using UnityEngine;

namespace DaneF
{
    public class WarningZone : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject pillarSpawn;

        private float lifetime = 3.0f;
        private bool pillarSpawned = false;

        void Update()
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 1 && !pillarSpawned) 
            {
                pillarSpawned = true;
                Instantiate(pillarSpawn, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            if (lifetime <= 0) 
                Destroy(gameObject);
        }
    }
}