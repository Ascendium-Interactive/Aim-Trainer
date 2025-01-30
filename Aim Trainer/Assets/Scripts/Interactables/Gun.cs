using UnityEngine;

public class Gun : Interactable
{
    [SerializeField]
    private Transform equipPoint;
    private bool isEquipped = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Interact()
    {
        if (!isEquipped)
        {
            transform.SetParent(equipPoint);

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;

            isEquipped = true;

            // Get reference to PlayerInteract
            PlayerInteract playerInteract = FindFirstObjectByType<PlayerInteract>(); // Ensures the player exists
            if (playerInteract != null)
            {
                playerInteract.SetEquippedGun(this);
            }
        }

        Debug.Log("Interacted with " + gameObject.name);
    }

    public void Shoot()
    {
        if (isEquipped)
        {
            //Call to audio and animation animator.play("shoot");
        }
    }
}