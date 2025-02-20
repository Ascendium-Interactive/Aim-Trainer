using UnityEngine;

public class Target : TargetShot
{

    public TargetManager targetManager;

    public int maxPoints = 10;
    public int minPoints = 1;
    private float maxRadius = .9f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the TargetManager in the scene
        targetManager = FindAnyObjectByType<TargetManager>();

        // Check if the TargetManager is found
        if (targetManager == null)
        {
            Debug.LogError("TargetManager not found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ShootTarget()
    {
        if (targetManager != null)
        {
            targetManager.OnTargetDestroyed();
        }
        //Debug.Log("Interacted with " + gameObject.name);
        Destroy(gameObject);
    }

    public int GetScore(Vector3 hitPoint)
    {
        float distance = Vector3.Distance(hitPoint, transform.position);

        if (distance > maxRadius)
        {
            return minPoints;
        }

        float t = Mathf.InverseLerp(maxRadius, 0, distance);
        return Mathf.RoundToInt(Mathf.Lerp(minPoints, maxPoints, t));
    }
}
