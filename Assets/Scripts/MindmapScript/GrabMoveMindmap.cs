using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMoveMindmap : MonoBehaviour
{
    public GameObject R_Hand, XRRig;
    public Vector3 difference, oldhandpos, currenthandpos;
    public float smoothSpeed = 1f;
    
    protected float previousControllerDistance;
   
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            
            currenthandpos = R_Hand.transform.position;
            // Get the difference between the previous frame's hand position and this frame's current hand position
            difference = difference = (oldhandpos - currenthandpos) * 1f;
            // Add that difference to the camerarig
            XRRig.transform.position += difference;
        }

        oldhandpos = R_Hand.transform.position;
    }
}
