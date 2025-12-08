using UnityEngine;

namespace DaneF
{
    public class BossScript : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject playerBody;
        StateMachine stateMachine;
        [SerializeField] Animator animator;

        [Header("Boss Variables")]
        [SerializeField] float bossHealth = 60.0f;
        [SerializeField] float bossMoveSpeed = 5.0f;
        public float bossRotationSpeed = 5.0f;

        public float countdown = 10.0f;
        public int rng = 0;

        public float playerDistance { get; private set; }
        public Vector3 playerDirection { get; private set; }
        public bool ultimateToken { get; private set; }
        public float phase { get; private set; }
        private float maxBossHealth;
        public float maxRotationSpeed { get; private set; }
        private float bossDefense = 50.0f;

        //Animation Booleans
        bool isIdle = true;
        bool isChase = false;
        bool isBite = false;
        bool isLaser = false;
        bool isShockwave = false;
        bool isRush = false;
        bool isFire = false;
        bool isDie = false;

        void Start()
        {
            stateMachine = new StateMachine(this);
            stateMachine.ChangeState(new EnemyIdleState(stateMachine));
            ultimateToken = false;
            phase = 0.0f;
            maxBossHealth = bossHealth;
            maxRotationSpeed = bossRotationSpeed;
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

        #region Animations
        public void AnimateIdle() 
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isChase", false);
            animator.SetBool("isBite", false);
            animator.SetBool("isLaser", false);
            animator.SetBool("isShockwave", false);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", false);
            animator.SetBool("isDie", false);
        }

        public void AnimateChase()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isChase", true);
            animator.SetBool("isBite", false);
            animator.SetBool("isLaser", false);
            animator.SetBool("isShockwave", false);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", false);
            animator.SetBool("isDie", false);
        }

        public void AnimateBite()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isChase", false);
            animator.SetBool("isBite", true);
            animator.SetBool("isLaser", false);
            animator.SetBool("isShockwave", false);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", false);
            animator.SetBool("isDie", false);
        }

        public void AnimateLaser()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isChase", false);
            animator.SetBool("isBite", false);
            animator.SetBool("isLaser", true);
            animator.SetBool("isShockwave", false);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", false);
            animator.SetBool("isDie", false);
        }

        public void AnimateShockwave()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isChase", false);
            animator.SetBool("isBite", false);
            animator.SetBool("isLaser", false);
            animator.SetBool("isShockwave", true);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", false);
            animator.SetBool("isDie", false);
        }

        public void AnimateRush()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isChase", false);
            animator.SetBool("isBite", false);
            animator.SetBool("isLaser", false);
            animator.SetBool("isShockwave", true);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", false);
            animator.SetBool("isDie", false);
        }

        public void AnimateDie()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isChase", false);
            animator.SetBool("isBite", false);
            animator.SetBool("isLaser", false);
            animator.SetBool("isShockwave", false);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", false);
            animator.SetBool("isDie", true);
        }

        public void AnimateFire()
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isChase", false);
            animator.SetBool("isBite", false);
            animator.SetBool("isLaser", false);
            animator.SetBool("isShockwave", false);
            animator.SetBool("isRush", false);
            animator.SetBool("isFire", true);
            animator.SetBool("isDie", false);
        }
        #endregion
    }
}