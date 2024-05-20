using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private float nodeRadius = 0.045f;
    private Transform startTransform;
    public GameObject nodePrefab1, nodePrefab2;
    private Vector3 endPoint;
    public bool isAttached = false;

    public void Initialize(Transform start, GameObject nodePrefab1, Rope rope)
    {
        var node = nodePrefab1.GetComponent<MindmapNode>();
        if (node.IsLinked)
        {
            node.DisconnectRope();
        }
        node.SetLinked(true, rope);
        lineRenderer = GetComponent<LineRenderer>();
        startTransform = start;
        this.nodePrefab1 = nodePrefab1;
        lineRenderer.positionCount = 2;
        // Define positions for the line
        lineRenderer.SetPosition(0, nodePrefab1.transform.position); // Starting point
        lineRenderer.SetPosition(1, start.position); // Ending point
        
    }

    public void UpdateEndPoint(Vector3 end)
    {
        Debug.Log("update" + end);
        if (isAttached) return;

        endPoint = end;
        lineRenderer.SetPosition(1, endPoint);
    }
    public void SetNode2(GameObject nodePrefab2)
    {
        this.nodePrefab2 = nodePrefab2;
    }
    public void Detach()
    {
        if (isAttached) return;
        var node = nodePrefab1.GetComponent<MindmapNode>();
        //Collider[] hitColliders = Physics.OverlapSphere(endPoint, nodeRadius);
        //foreach (var hitCollider in hitColliders)
        //{
        //    if (hitCollider.gameObject != startTransform.gameObject)
        //    {
        //        AttachToNode(hitCollider.transform);
        //        node.SetLinked(true);
        //        return;
        //    }
        //}
        if (nodePrefab2 != null )
        {
            AttachToNode(nodePrefab2.transform);
            node.SetLinked(true);
            return;
        }
        else
        {
            node.SetLinked(false);
            isAttached = false;
            return;
        }
    }

    private void AttachToNode(Transform node)
    {
        isAttached = true;
        endPoint = node.position;
        lineRenderer.SetPosition(1, endPoint);
    }


}