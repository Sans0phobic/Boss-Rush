using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DaneF
{
    public class BossScript : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject playerBody;
        StateMachine stateMachine;
        [SerializeField] Animator animator;
        [SerializeField] GameObject collisionHead;
        [SerializeField] GameObject collisionShoulders;
        [SerializeField] GameObject collisionLaser;
        [SerializeField] GameObject collisionRoar;
        GameManager gameManager;

        [Header("Boss Variables")]
        public float bossHealth = 60.0f;
        public float bossMoveSpeed = 5.0f;
        public float bossRotationSpeed = 5.0f;
        public bool isDead = false;
        public float countdown = 10.0f;
        public int rng = 0;
        private float iframes = 0.5f;

        public float playerDistance { get; private set; }
        public Vector3 playerDirection { get; private set; }
        public bool ultimateToken { get; private set; }
        public float phase { get; private set; }
        public float maxBossHealth { get; private set; }
        public float maxRotationSpeed { get; private set; }
        public float maxSpeed { get; private set; }
        private float bossDefense = 50.0f;
        public UnityEvent ShareDamage;
        public UnityEvent ActivateLaser;

        //Animation Booleans
        private bool isIdle = true;
        private bool isChase = false;
        private bool isBite = false;
        private bool isLaser = false;
        private bool isShockwave = false;
        private bool isRush = false;
        private bool isFire = false;
        private bool isDie = false;

        [Header("Collision Checkers")]
        public bool collisionHeadActive = false;
        public bool collisionShouldersActive = false;
        public bool collisionLaserActive = false;
        public bool collisionRoarActive = false;

        void Start()
        {
            stateMachine = new StateMachine(this);
            stateMachine.ChangeState(new EnemyIdleState(stateMachine));
            ultimateToken = false;
            phase = 0.0f;
            maxBossHealth = bossHealth;
            maxRotationSpeed = bossRotationSpeed;
            maxSpeed = bossMoveSpeed;
        }

        void Update()
        {
            if (isDead) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }
            playerDistance = Vector3.Distance(transform.position, playerBody.transform.position);
            playerDirection = (playerBody.transform.position - transform.position).normalized;
            //Debug.Log("Player Distance: " + playerDistance);
            iframes -= Time.deltaTime;
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
            if (iframes <= 0)
            {
                iframes = 0.5f;
                Debug.Log("hit");
                bossHealth -= 2;
                ShareDamage?.Invoke();
            }

            if ((bossHealth / maxBossHealth) * 100 <= 20) 
            {
                phase = 2.0f;
            }
            else if (bossHealth <= maxBossHealth / 2)
            {
                phase = 1.0f;
            }
        }

        public void StartLaser() 
        {
            ActivateLaser?.Invoke();
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
            animator.SetBool("isShockwave", false);
            animator.SetBool("isRush", true);
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