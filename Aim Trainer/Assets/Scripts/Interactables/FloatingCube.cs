using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCube : Interactable
{
    [SerializeField]
    private float distance = 5f;
                    
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
        transform.Translate(Vector3.up * distance);
        Debug.Log("Interacted with " + gameObject.name);
    }
}
