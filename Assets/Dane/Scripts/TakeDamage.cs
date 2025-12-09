using UnityEngine;

namespace DaneF
{
    public class TakeDamage : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] GameObject ground;
        BossScript bossScript;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject != player && collision.gameObject != ground)
            {
                bossScript.getHit();
            }
        }
    }
}