using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RopeLink : MonoBehaviour
{
    public GameObject ropePrefab;
    public GameObject nodePrefab1;
    public GameObject R_Hand;
    private GameObject currentRope;

    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
        {
            StartRope();
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick) && currentRope != null)
        {
            UpdateRope();
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick) && currentRope != null)
        {
            EndRope();
        }
    }

    void StartRope()
    {
        
        if (nodePrefab1 == null || nodePrefab1.GetComponent<MindmapNode>().IsLinked)
        {
            // Don't start the rope if there's no node to attach to
            return;
        }
        currentRope = Instantiate(ropePrefab, R_Hand.transform.position, Quaternion.identity);
        currentRope.GetComponent<Rope>().Initialize(R_Hand.transform, nodePrefab1, currentRope.GetComponent<Rope>());
    }

    void UpdateRope()
    {
        var rope = currentRope.GetComponent<Rope>();
        rope.UpdateEndPoint(R_Hand.transform.position);
        rope.SetNode2(nodePrefab1);
    }

    void EndRope()
    {
        Rope ropeScript = currentRope.GetComponent<Rope>();
        ropeScript.Detach();
        ropeScript.SetNode2(null);
        if (ropeScript.isAttached == false)
        {
            Destroy(currentRope);
        }
        currentRope = null;
    }

}
