using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{

    public class Health : MonoBehaviour
    {
        private bool isDead = false;
        [SerializeField] float health = 100f;

        public void TakeDamage(float damageAmount)
        {
            health = Mathf.Max(health - damageAmount, 0);
            print(health.ToString());
            if(health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) return;
            GetComponent<Animator>().SetTrigger("die");
            isDead = true;
            GetComponent<ActionScheduler>().CancelCurrentAction();

        }

        public bool IsDead()
        {
            return isDead;
        }
    }
}