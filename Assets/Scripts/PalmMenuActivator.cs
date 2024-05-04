using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR; // For hand tracking (if using newer XR Input System)
// You may need a reference to your Oculus SDK depending on how you access hand tracking

public class PalmMenuActivator : MonoBehaviour
{
    public GameObject palmMenu;
    public InputDeviceCharacteristics handCharacteristics; // Left or right hand

    private InputDevice targetDevice;
    private bool previousPalmUpState = false;

    void Start()
    {
        palmMenu.SetActive(false); // Ensure menu is hidden initially

        // Get the target hand device
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(handCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation))
        {
            bool isPalmUp = IsPalmFacingUp(rotation);

            // Activate/Deactivate menu based on change in state
            if (isPalmUp && !previousPalmUpState)
            {
                palmMenu.SetActive(true);
            }
            else if (!isPalmUp && previousPalmUpState)
            {
                palmMenu.SetActive(false);
            }

            previousPalmUpState = isPalmUp;
        }
    }

    private bool IsPalmFacingUp(Quaternion rotation)
    {
        // Define your 'palm facing up' logic here (likely involving rotation thresholds)
        Vector3 palmForward = rotation * Vector3.forward; // Adjust as needed for your hand model
        float angleToUp = Vector3.Angle(palmForward, Vector3.up);
        return angleToUp < 60f; // Example using a 60-degree threshold
    }
}
