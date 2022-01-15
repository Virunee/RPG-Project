using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{

    public class Health : MonoBehaviour
    {
        private bool isDead = false;
        [SerializeField] float health = 100f;

        public void TakeDamage(float damageAmount)
        {
            health = Mathf.Max(health - damageAmount, 0);
            print(health.ToString());
            if(health <= 0 && !isDead)
            {
                GetComponent<Animator>().SetTrigger("die");
                isDead = true;
            }
        }

        public bool IsDead()
        {
            return isDead;
        }
    }
}