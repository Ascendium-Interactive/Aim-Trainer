using UnityEngine;

public abstract class TargetShot : MonoBehaviour
{
    public bool useEvents;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void BaseShoot()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        ShootTarget();
    }
    protected virtual void ShootTarget()
    {
        //template function to be overwritten
    }
}
