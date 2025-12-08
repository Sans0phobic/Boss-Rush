using UnityEngine;

namespace DaneF
{
    public class BossScript : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject playerBody;
        StateMachine stateMachine;

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
            stateMachine = new StateMachine(this);
            stateMachine.ChangeState(new EnemyIdleState(stateMachine));
            ultimateToken = false;
            phase = 0.0f;
            maxBossHealth = bossHealth;
        }

        void Update()
        {
            playerDistance = Vector3.Distance(transform.position, playerBody.transform.position);
            playerDirection = (playerBody.transform.position - transform.position).normalized;
            //Debug.Log("Player Distance: " + playerDistance);

            stateMachine.Update();
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