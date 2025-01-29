using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak47 : Interactable
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
        }

        Debug.Log("Interacted with " + gameObject.name);
    }
}
