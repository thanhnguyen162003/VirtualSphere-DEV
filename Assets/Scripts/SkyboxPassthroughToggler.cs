using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxPassthroughToggler : MonoBehaviour
{
    public Camera vrCamera;
    public Camera passthroughCamera;
    private bool isPassthroughEnabled = false;

    public void ToggleSkyboxPassthrough()
    {
        isPassthroughEnabled = !isPassthroughEnabled;
        vrCamera.enabled = !isPassthroughEnabled;
        passthroughCamera.enabled = isPassthroughEnabled;
    }
}
