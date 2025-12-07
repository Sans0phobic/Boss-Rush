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

        void Start()
        {

        }

        void Update()
        {
            playerDistance = Vector3.Distance(transform.position, playerBody.transform.position);
            Debug.Log("Player Distance: " + playerDistance);
            //Player melee range - 7m - Should ROAR here
            //Boss should CHASE at 20m
            //Boss should fire LASER at 30m
            //Boss should CLAW (technically bite) at 15m
        }
    }
}