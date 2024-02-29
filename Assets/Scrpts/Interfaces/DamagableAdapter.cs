using UnityEngine;
using UnityEngine.Events;

public class DamagableAdapter : MonoBehaviour, IDamagable
{
    // �������� �޴°� �̺�Ʈ�� ��������ش�.
    public UnityEvent<int> OnTakeDamaged;
    public void TakeDamage(int damage)
    {
        OnTakeDamaged?.Invoke(damage);
    }

    
}
