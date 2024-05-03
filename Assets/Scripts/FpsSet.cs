using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsSet : MonoBehaviour
{
    void Start()
    {
        //set the hz of glass to 90hz
        OVRPlugin.systemDisplayFrequency = 90.0f;
    }

}
