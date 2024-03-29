using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Collider attackCollider;
    [SerializeField] int damage;

    public void EnableWeapon()
    {
        attackCollider.enabled = true;
    }

    public void DisableWeapon()
    {
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        damagable?.TakeDamage(damage);
    }
}
