using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // For hand tracking (if using newer XR Input System)
// You may need a reference to your Oculus SDK depending on how you access hand tracking

public class PalmMenuActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject palmMenu;

    private bool isPalmOpen = false;

   void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if(isPalmOpen== false)
            {
                isPalmOpen = true;
                palmMenu.SetActive(true);
            }
            else
            {
                isPalmOpen = false;
                palmMenu.SetActive(false);
            }
        }
        
    }
}
