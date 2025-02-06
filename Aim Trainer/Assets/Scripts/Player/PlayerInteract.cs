using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask interactableMask;
    [SerializeField]
    private LayerMask targetMask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    private Gun equippedGun; // Stores the equipped gun
    private bool gunEquipped = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        //creates ray from center of camera
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, interactableMask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }

        // Shooting logic
        if (inputManager.onFoot.Shoot.triggered && gunEquipped && equippedGun != null)
        {
            ShootGun();
            equippedGun.Shoot();
        }

    }

    // Method to set the equipped gun
    public void SetEquippedGun(Gun gun)
    {
        equippedGun = gun;
        gunEquipped = true;
        interactableMask = 0;
    }

    private void ShootGun()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, targetMask))
        {
            if (hitInfo.collider.GetComponent<Target>() != null)
            {
                TargetShot target = hitInfo.collider.GetComponent<Target>();
                if (inputManager.onFoot.Shoot.triggered)
                {
                    target.BaseShoot();
                }
            }
        }
    }
}
