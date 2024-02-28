using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float range;
    [SerializeField] float attackangle;
    [SerializeField] int damage;
    //[SerializeField] Weapon weapon;
    private void Attack()
    {

        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            animator.SetTrigger("Attack1");
        }
        else { animator.SetTrigger("Attack2"); }
    }

    Collider[] colliders = new Collider[20];
    private void AttackTiming()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
        for (int i = 0; i < size; i++)
        {
            Vector3 dirToTarger= (colliders[i].transform.position - transform.position).normalized;
            // Angle은 연산이 느려지니 다른 방식을 사용해야된다.
            if (Vector3.Angle(transform.forward, dirToTarger) > 90) continue;

            IDamagable damagable = colliders[i].GetComponent<IDamagable>();
            damagable?.TakeDamage(damage);

        }
    }

    /* public void EnableWeapon()
     {
         weapon.EnableWeapon();
     }
     public void DisableWeapon()
     {
         weapon.DisableWeapon();
     }*/
    private void OnAttack(InputValue value)
    {
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}