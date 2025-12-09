using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DaneF
{
    public class BossScript : MonoBehaviour
    {
        #region References
        [Header("References")]
        [SerializeField] GameObject playerBody;
        StateMachine stateMachine;
        [SerializeField] Animator animator;
        [SerializeField] GameObject collisionHead;
        [SerializeField] GameObject collisionShoulders;
        [SerializeField] GameObject collisionLaser;
        [SerializeField] GameObject collisionRoar;
        //GameManager gameManager;
        #endregion

        #region Boss Variables
        [Header("Boss Variables")]
        public float bossHealth = 60.0f;
        public float bossMoveSpeed = 5.0f;
        public float bossRotationSpeed = 5.0f;
        public bool isDead = false;
        public float countdown = 10.0f;
        public int rng = 0;
        private float iframes = 0.5f;
        public bool ultimateToken = false;
        #endregion

        #region Misc. Variables
        public float playerDistance { get; private set; }
        public Vector3 playerDirection { get; private set; }
        public float phase { get; private set; }
        public float maxBossHealth { get; private set; }
        public float maxRotationSpeed { get; private set; }
        public float maxSpeed { get; private set; }
        private bool ultChecker = true;
        #endregion

        #region Unity Events
        public UnityEvent ShareDamage;
        public UnityEvent ShareDead;
        public UnityEvent ActivateLaser;
        public UnityEvent ActivateRoar;
        public UnityEvent ActivateSwipe;
        public UnityEvent ActivateCharge;
        public UnityEvent ActivateUlt;
        public UnityEvent ActivateUltShock;
        #endregion

        #region Animation Booleans
        private bool isIdle = true;
        private bool isChase = false;
        private bool isBite = false;
        private bool isLaser = false;
        private bool isShockwave = false;
        private bool isRush = false;
        private bool isFire = false;
        private bool isDie = false;
        #endregion

        #region Collision Checkers
        [Header("Collision Checkers")]
        public bool collisionHeadActive = false;
        public bool collisionShouldersActive = false;
        public bool collisionLaserActive = false;
        public bool collisionRoarActive = false;
        #endregion

        void Start()
        {
            stateMachine = new StateMachine(this);
            stateMachine.ChangeState(new EnemyIdleState(stateMachine));
            phase = 0.0f;
            maxBossHealth = bossHealth;
            maxRotationSpeed = bossRotationSpeed;
            maxSpeed = bossMoveSpeed;
        }

        void Update()
        {
            if (isDead) 
            {
                //I added this becuase I'm dumb & couldn't get the connection to the GameManager working
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

            if ((bossHealth / maxBossHealth) * 100 <= 30) 
            {
                phase = 2.0f;
                Debug.Log("Boss Phase 3");
                if (ultChecker) 
                {
                    Debug.Log("ultChecked");
                    ultChecker = false;
                    ultimateToken = true;
                }
            }
            else if (bossHealth <= maxBossHealth / 2)
            {
                phase = 1.0f;
                Debug.Log("Boss Phase 2");
            }
        }

        #region Event Handlers
        public void TriggerOnDeath() 
        {
            ShareDead?.Invoke();
        }

        public void StartLaser() 
        {
            ActivateLaser?.Invoke();
        }

        public void StartRoar() 
        {
            ActivateRoar?.Invoke();
        }

        public void StartBite() 
        {
            ActivateSwipe?.Invoke();
        }

        public void StartCharge() 
        {
            ActivateCharge?.Invoke();
        }

        public void StartUltimate() 
        {
            ActivateUlt?.Invoke();
        }

        public void StartUltimateShock() 
        {
            ActivateUltShock?.Invoke();
        }
        #endregion

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