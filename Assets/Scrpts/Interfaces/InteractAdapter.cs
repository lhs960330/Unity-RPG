using UnityEngine;
using UnityEngine.Events;

public class InteractAdapter : MonoBehaviour, IInteractble
{
    public UnityEvent<PlayerInteractor> OnInteracted;  
    public void Interact(PlayerInteractor player)
    {
        OnInteracted?.Invoke(player);
    }
}
