using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    public OVRInput.Button dragButton = OVRInput.Button.SecondaryIndexTrigger;
    private GameObject grabbedObject;
    private Vector3 grabOffset;

    void Update()
    {
        if (OVRInput.Get(dragButton) && grabbedObject != null)
        {
            grabbedObject.transform.position = transform.position + grabOffset;
        }

        if (OVRInput.GetDown(dragButton))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                grabbedObject = hit.collider.gameObject;
                grabOffset = grabbedObject.transform.position - transform.position;
            }
        }

        if (OVRInput.GetUp(dragButton))
        {
            grabbedObject = null;
        }
    }
}
