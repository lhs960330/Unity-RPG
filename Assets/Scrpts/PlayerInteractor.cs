using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] bool debug;
    [SerializeField] float range;

    Collider[] colliders = new Collider[20];
    private void Interact()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, range, colliders);
        for(int i = 0; i < size; i++) 
        {
            IInteractble interactble = colliders[i].GetComponent<IInteractble>();
            if(interactble != null)
            {
                interactble.Interact(this);
                break;
            }
        }
    }

    public void OnInteract(InputValue Value)
    {
        Interact();
    }

    private void OnDrawGizmos()
    {
        // bool�� ���� �ʿ������ Gizmos ���������ִ�.(���Ǽ�)
        if (debug)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
