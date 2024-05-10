using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicManager : MonoBehaviour
{

    private Transform highlightRight;
    private Transform selectionRight;

    private Transform highlightLeft;
    private Transform selectionLeft;
    
    private float maxDistance = 0.2f; // How far the raycast can reach
    [SerializeField] private LayerMask selectableLayerMask;
    [SerializeField] private GameObject rightController;
    [SerializeField] private GameObject leftController;
    private void Update()
    {
        //// Highlight
        //if (highlightRight != null)
        //{
        //    highlightRight.gameObject.GetComponent<Outline>().enabled = false;
        //    highlightRight = null;
        //}
        //if (highlightLeft != null)
        //{
        //    highlightLeft.gameObject.GetComponent<Outline>().enabled = false;
        //    highlightLeft = null;
        //}

        if (RaycastVRController(rightController, out RaycastHit raycastHitRight, maxDistance, selectableLayerMask))
        {
            //Debug.Log("Raycast Success");
            highlightRight = raycastHitRight.transform;
            if (highlightRight.TryGetComponent(out MindmapNodeScript mindmapNode))
            {
                //Debug.Log("Get Component Success");
                if (mindmapNode.gameObject.GetComponent<Outline>() != null)
                {
                    //Debug.Log("Outline is NOT NULL");
                    mindmapNode.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    //Debug.Log("Outline is NULL");
                    Outline outline = mindmapNode.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    mindmapNode.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
                    mindmapNode.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                //Debug.Log("Get Component Fail");
                mindmapNode.gameObject.GetComponent<Outline>().enabled = false;
                highlightRight = null;
            }
        }
        else
        {
            if (highlightRight != null)
            {
                highlightRight.gameObject.GetComponent<Outline>().enabled = false;
                highlightRight = null;
            }
            
        }
        #region Reset RIGHT highlight and selected node logic
        if (highlightRight != null)
        {
            //if (selectionRight != null)
            //{
            //    //selectionRight.gameObject.GetComponent<Outline>().enabled = false;
            //}
            //selectionRight = raycastHitRight.transform;
            //selectionRight.gameObject.GetComponent<Outline>().enabled = true;
            //highlightRight = null;
        }
        else
        {
            //if (selectionRight != null)
            //{
            //    selectionRight.gameObject.GetComponent<Outline>().enabled = false;
            //    selectionRight = null;
            //    highlightRight = null;
            //}
        }
        #endregion
        //if (RaycastVRController(leftController, out RaycastHit raycastHitLeft, maxDistance, selectableLayerMask))
        //{
        //    //Debug.Log("Raycast Success");
        //    highlightLeft = raycastHitLeft.transform;
        //    if (highlightLeft.TryGetComponent(out MindmapNodeScript mindmapNode) && highlightLeft != selectionLeft)
        //    {
        //        //Debug.Log("Get Component Success");
        //        if (mindmapNode.gameObject.GetComponent<Outline>() != null)
        //        {
        //            //Debug.Log("Outline is NOT NULL");
        //            mindmapNode.gameObject.GetComponent<Outline>().enabled = true;
        //        }
        //        else
        //        {
        //            //Debug.Log("Outline is NULL");
        //            Outline outline = mindmapNode.gameObject.AddComponent<Outline>();
        //            outline.enabled = true;
        //            mindmapNode.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
        //            mindmapNode.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
        //        }
        //    }
        //    else
        //    {
        //        //Debug.Log("Get Component Fail");
        //        highlightLeft = null;
        //    }
        //}
        //#region Reset LEFT highlight and selected node logic
        //if (highlightLeft != null)
        //{
        //    if (selectionLeft != null)
        //    {
        //        selectionLeft.gameObject.GetComponent<Outline>().enabled = false;
        //    }
        //    selectionLeft = raycastHitLeft.transform;
        //    selectionLeft.gameObject.GetComponent<Outline>().enabled = true;
        //    highlightLeft = null;
        //}
        //else
        //{
        //    if (selectionLeft != null)
        //    {
        //        selectionLeft.gameObject.GetComponent<Outline>().enabled = false;
        //        selectionLeft = null;
        //    }
        //}
        //#endregion
    }

    public bool RaycastVRController(GameObject controller, out RaycastHit raycastHit, float maxDistance, int layerMask)
    {
        Ray ray = new Ray(controller.transform.position, controller.transform.forward);
        if (Physics.Raycast(ray, out raycastHit, maxDistance, layerMask))
        {
            return true;
        }
        return false;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GameLogicManager : MonoBehaviour
//{

//    private Transform highlightRight;
//    private Transform selectionRight;

//    private Transform highlightLeft;
//    private Transform selectionLeft;

//    private float radius = 20.0f; // How far the raycast can reach
//    [SerializeField] private LayerMask selectableLayerMask;
//    [SerializeField] private GameObject rightController;
//    [SerializeField] private GameObject leftController;
//    private void Update()
//    {
//        // Highlight
//        if (highlightRight != null)
//        {
//            highlightRight.gameObject.GetComponent<Outline>().enabled = false;
//            highlightRight = null;
//        }
//        if (highlightLeft != null)
//        {
//            highlightLeft.gameObject.GetComponent<Outline>().enabled = false;
//            highlightLeft = null;
//        }

//        if (OverlapCastVRController(rightController, out Transform transformRight, radius, selectableLayerMask))
//        {
//            Debug.Log("Raycast Success");
//            highlightRight = transformRight;
//            if (highlightRight.gameObject.TryGetComponent(out MindmapNodeScript mindmapNode) && highlightRight != selectionRight)
//            {
//                Debug.Log("Get Component Success");
//                if (mindmapNode.gameObject.GetComponent<Outline>() != null)
//                {
//                    Debug.Log("Outline is NOT NULL");
//                    mindmapNode.gameObject.GetComponent<Outline>().enabled = true;
//                }
//                else
//                {
//                    Debug.Log("Outline is NULL");
//                    Outline outline = mindmapNode.gameObject.AddComponent<Outline>();
//                    outline.enabled = true;
//                    mindmapNode.gameObject.GetComponent<Outline>().OutlineColor = Color.red;
//                    mindmapNode.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
//                }
//            }
//            else
//            {
//                Debug.Log("Get Component Fail");
//                highlightRight = null;
//            }
//        }
//        #region Reset RIGHT highlight and selected node logic
//        if (highlightRight != null)
//        {
//            if (selectionRight != null)
//            {
//                selectionRight.gameObject.GetComponent<Outline>().enabled = false;
//            }
//            selectionRight = transformRight.transform;
//            selectionRight.gameObject.GetComponent<Outline>().enabled = true;
//            highlightRight = null;
//        }
//        else
//        {
//            if (selectionRight != null)
//            {
//                selectionRight.gameObject.GetComponent<Outline>().enabled = false;
//                selectionRight = null;
//            }
//        }
//        #endregion
//        if (OverlapCastVRController(leftController, out Transform transformLeft, radius, selectableLayerMask))
//        {
//            Debug.Log("LEFT - Raycast Success");
//            highlightLeft = transformLeft;
//            if (highlightLeft.gameObject.TryGetComponent(out MindmapNodeScript mindmapNode) && highlightLeft != selectionLeft)
//            {
//                Debug.Log("LEFT - Get Component Success");
//                if (mindmapNode.gameObject.GetComponent<Outline>() != null)
//                {
//                    Debug.Log("LEFT - Outline is NOT NULL");
//                    mindmapNode.gameObject.GetComponent<Outline>().enabled = true;
//                }
//                else
//                {
//                    Debug.Log("LEFT - Outline is NULL");
//                    Outline outline = mindmapNode.gameObject.AddComponent<Outline>();
//                    outline.enabled = true;
//                    mindmapNode.gameObject.GetComponent<Outline>().OutlineColor = Color.white;
//                    mindmapNode.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
//                }
//            }
//            else
//            {
//                Debug.Log("LEFT - Get Component Fail");
//                highlightLeft = null;
//            }
//        }
//        #region Reset LEFT highlight and selected node logic
//        if (highlightLeft != null)
//        {
//            if (selectionLeft != null)
//            {
//                selectionLeft.gameObject.GetComponent<Outline>().enabled = false;
//            }
//            selectionLeft = transformLeft.transform;
//            selectionLeft.gameObject.GetComponent<Outline>().enabled = true;
//            highlightLeft = null;
//        }
//        else
//        {
//            if (selectionLeft != null)
//            {
//                selectionLeft.gameObject.GetComponent<Outline>().enabled = false;
//                selectionLeft = null;
//            }
//        }
//        #endregion
//    }

//    public bool OverlapCastVRController(GameObject controller, out Transform overlapSphereFirstHit, float radius, int layerMask)
//    {
//        var collirdersHitArray = Physics.OverlapSphere(controller.transform.position, radius, layerMask);
//        if (collirdersHitArray.Length > 0)
//        {
//            overlapSphereFirstHit = GetClosestObject(collirdersHitArray);
//            return true;
//        }
//        overlapSphereFirstHit = null;
//        return false;
//    }
//    private Transform GetClosestObject(Collider[] objects)
//    {
//        Transform bestTarget = null;
//        float closestDistanceSqr = Mathf.Infinity;
//        Vector3 currentPosition = transform.position;
//        foreach (Collider potentialTarget in objects)
//        {
//            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
//            float dSqrToTarget = directionToTarget.sqrMagnitude;
//            if (dSqrToTarget < closestDistanceSqr)
//            {
//                closestDistanceSqr = dSqrToTarget;
//                bestTarget = potentialTarget.transform;
//            }
//        }

//        return bestTarget;
//    }
//}