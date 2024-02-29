using UnityEngine;
using UnityEngine.Events;

public class DamagableAdapter : MonoBehaviour, IDamagable
{
    // 데미지를 받는걸 이벤트로 변경시켜준다.
    public UnityEvent<int> OnTakeDamaged;
    public void TakeDamage(int damage)
    {
        OnTakeDamaged?.Invoke(damage);
    }

    
}
