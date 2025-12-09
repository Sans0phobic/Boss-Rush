using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace DaneF
{
    public class UltManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject ground;
        [SerializeField] GameObject warning;

        [Header("Spawn Variables")]
        [SerializeField] float spawnTimerMax = 10.5f;
        [SerializeField] int spawnBurstMax = 50;

        private float xPoint;
        private float zPoint;
        private float spawnTimer = 0;

        private bool activateSpawn = false;
        private int spawnBurst;
        private float groundSizeX;
        private float groundSizeZ;

        void Start()
        {
            spawnBurst = spawnBurstMax;
        }

        void Update()
        {
            if (!activateSpawn) 
            {

            }
            else
            {
                //Spawns the warning GameObject at a random position on the ground
                spawnTimer -= Time.deltaTime;

                if (spawnTimer <= 0)
                {
                    while (spawnBurst > 0)
                    {
                        Instantiate(warning, spawnPos(), Quaternion.identity);
                        spawnBurst--;
                    }
                    spawnTimer = spawnTimerMax;
                    spawnBurst = spawnBurstMax;
                }
            }
        }

        public void ActivateUltimate()
        {
            activateSpawn = true;
        }

        public void DeactivateUltimate() 
        {
            activateSpawn = false;
            Destroy(gameObject);
        }

        private Vector3 spawnPos() 
        {
            Vector3 center = ground.transform.position;
            groundSizeX = ground.transform.localScale.x * 10.0f;
            groundSizeZ = ground.transform.localScale.z * 10.0f;

            xPoint = Random.Range(center.x - groundSizeX / 2, center.x + groundSizeX / 2);
            zPoint = Random.Range(center.z - groundSizeZ / 2, center.z + groundSizeZ / 2);

            return new Vector3(xPoint, 0.1f, zPoint);
        }
    }
}