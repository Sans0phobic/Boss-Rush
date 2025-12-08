using UnityEngine;

namespace DaneF
{
    public class BossScript : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject playerBody;

        [Header("Boss Variables")]
        [SerializeField] float bossHealth = 60.0f;
        [SerializeField] float bossMoveSpeed = 5.0f;
        [SerializeField] float bossRotationSpeed = 5.0f;

        public float countdown = 10.0f;
        public int rng = 0;

        public float playerDistance { get; private set; }
        public Vector3 playerDirection { get; private set; }
        public bool ultimateToken { get; private set; }
        public float phase { get; private set; }
        private float maxBossHealth;
        private float bossDefense = 50.0f;

        void Start()
        {
            ultimateToken = false;
            phase = 0.0f;
            maxBossHealth = bossHealth;
        }

        void Update()
        {
            playerDistance = Vector3.Distance(transform.position, playerBody.transform.position);
            playerDirection = (playerBody.transform.position - transform.position).normalized;
            Debug.Log("Player Distance: " + playerDistance);
            //lookAtPlayer();

            //Boss should use FIRE PILLAR attack the next time they idle & are at 5% health or less
            //if(health <= 5%) {FIRE PILLAR}
            //Player melee range - 8m - Should ROAR here after a few seconds
            if (playerDistance <= 8)
            {
                //Start timer 10 second timer using the 'countdown' variable
                countdown -= Time.deltaTime;
                if (countdown <= 0) 
                {
                    Debug.Log("EnemyShockwaveState");
                }
            }
            //Boss should CLAW (technically bite) at 15m
            if (playerDistance > 8 && playerDistance <= 15) 
            {
                Debug.Log("EnemySwipeState");
                countdown = 10.0f;
            }
            //Boss should CHASE at 15 - 25m
            if (playerDistance > 15 && playerDistance <= 25)
            {
                Debug.Log("EnemyChaseState");
            }
            //Boss should fire LASER in phase 1, or fire LASER/CHARGE at 25m in phase 2
            if (playerDistance > 25)
            {
                if (rng == 0)
                    Debug.Log("EnemyLaserState");
                if (rng == 1)
                    Debug.Log("EnemyChargeState");

                //if in phase two, rng = Random.Range(0, 2);
            }
        }

        public void lookAtPlayer() 
        {
            Quaternion rotation = Quaternion.LookRotation(playerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * bossRotationSpeed);
        }

        public void chasePlayer() 
        {
            transform.position = Vector3.MoveTowards(transform.position, playerBody.transform.position, bossMoveSpeed * Time.deltaTime);
        }

        public int randomNumber() 
        {
            rng = Random.Range(0, 2);
            return rng;
        }
        public void getHit() 
        {

            if ((bossHealth / maxBossHealth) * 100 <= 20) 
            {
                phase = 2.0f;
            }
            else if (bossHealth <= maxBossHealth / 2)
            {
                phase = 1.0f;
            }
        }
    }
}