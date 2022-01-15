using System.Collections;
using UnityEngine;
using RPG.Movement;
using RPG.Core;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {

        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;
        [SerializeField] float weaponDamage = 10f;

        Transform target;
        float timeSinceLastAttack = 0;
        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            bool isInRange =  Vector3.Distance(transform.position, target.position) < weaponRange;
            if(!isInRange)
            {
               
                GetComponent<Mover>().MoveTo(target.position);
            } else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
        if (timeSinceLastAttack > timeBetweenAttacks)
            {
                // This will trigger the Hit() animation event
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0;
            }
        }

        // Animation Event
        void Hit()
        {
            target.GetComponent<Health>().TakeDamage(weaponDamage);
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }
        
    }
}