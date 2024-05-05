using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelection : MonoBehaviour
{
    private Transform highlight;
    public OVRInput.Controller controller = OVRInput.Controller.RTouch; // Specify the controller
    public float raycastDistance = 2.0f; // How far the raycast can reach

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        // Generate Ray from Controller
        Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(controller);
        Vector3 controllerForward = OVRInput.GetLocalControllerRotation(controller).eulerAngles;
        Ray ray = new Ray(controllerPosition, controllerForward); // Or use transform.forward

        if (Physics.Raycast(ray, out RaycastHit raycastHit, raycastDistance))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable"))
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }
    }
}