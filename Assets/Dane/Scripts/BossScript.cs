using UnityEngine;

namespace DaneF
{
    public class BossScript : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject playerBody;

        [Header("Boss Variables")]
        [SerializeField] float bossHealth = 60.0f;
        [SerializeField] float bossSpeed = 5.0f;

        private float playerDistance;
        private int rng = 0;
        private float countdown;

        void Start()
        {

        }

        void Update()
        {
            playerDistance = Vector3.Distance(transform.position, playerBody.transform.position);
            Debug.Log("Player Distance: " + playerDistance);
            //Player melee range - 7m - Should ROAR here after a few seconds
            //Boss should CHASE at 8 - 29m
            //Boss should fire LASER or CHARGE at 30m
            //Boss should CLAW (technically bite) at 15m
            //Boss should use FIRE PILLAR attack the next time they idle & are at 5% health or less

            if (playerDistance <= 7)
            {
                Debug.Log("EnemyShockwaveState");
                //Start timer 10 second timer using the 'countdown' variable
                //countdown -= Time.deltaTime;
                //if(countdown <= 0) {shockwave}
            }
            if (playerDistance > 7 && playerDistance <= 15) 
            {
                Debug.Log("EnemySwipeState");
                //countdown = 10.0f;
            }
            if (playerDistance >15 && playerDistance <= 29)
            {
                Debug.Log("EnemyChaseState");
            }
            if (playerDistance >= 30)
            {
                if (rng == 0)
                    Debug.Log("EnemyLaserState");
                if (rng == 1)
                    Debug.Log("EnemyChargeState");
            }
        }
    }
}