using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindmapLogicManager : MonoBehaviour
{
    #region Events
    public event EventHandler<OnSelectedMindmapNodeChangedEventArgs> OnSelectedMindmapNodeChanged;
    #endregion

    #region Event Arguments Type
    public class OnSelectedMindmapNodeChangedEventArgs : EventArgs
    {
        public MindmapNode selectedMindmapNode;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Singleton instance of this class
    /// </summary>
    public static MindmapLogicManager Instance { get; private set; }

    /// <summary>
    /// Max distance of the cast from controller
    /// </summary>
    private float maxDistance = 0.045f; // How far the raycast can reach

    /// <summary>
    /// Object's layer type catched in the cast
    /// </summary>
    [SerializeField] private LayerMask selectableLayerMask;

    /// <summary>
    /// The right controller
    /// </summary>
    [SerializeField] private GameObject rightController;

    /// <summary>
    /// The left controlelr
    /// </summary>
    [SerializeField] private GameObject leftController;

    /// <summary>
    /// The selected/hovered mindmap node for the right controller
    /// </summary>
    private MindmapNode selectedNodeRight;

    /// <summary>
    /// The selected/hovered mindmap node for the left controller
    /// </summary>
    private MindmapNode selectedNodeLeft;
    #endregion

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        //Only 1 controller hover at a time
        if (this.selectedNodeLeft == null)
        {
            HandleSelectedNodeForRightController();
        }
        if (this.selectedNodeRight == null)
        {
            HandleSelectedNodeForLeftController();
        }            
    }

    #region Methods

    /// <summary>
    /// Handle logic for when right controller is hover over mindmap node
    /// </summary>
    private void HandleSelectedNodeForRightController()
    {
        if (rightController != null)
        {
            Collider[] hitObjectsArray = Physics.OverlapSphere(rightController.transform.position, maxDistance, selectableLayerMask);
            //CASE 1.1: Right controller is not null
            if (hitObjectsArray.Length > 0)
            {
                //CASE 2.1: Right controller cast hit something
                Transform closestObjectHit = GetClosestObject(hitObjectsArray, rightController);
                if (closestObjectHit.TryGetComponent(out MindmapNode node))
                {
                    //CASE 3.1: Successfully detect a mindmap node
                    if (node != this.selectedNodeRight)
                    {
                        SetSelectedNodeRight(node);
                    }
                }
                else
                {
                    //CASE 3.2: Fail to detect a mindmap node
                    SetSelectedNodeRight(null);
                }
            }
            else
            {
                //CASE 2.2: Right controller hit nothing
                SetSelectedNodeRight(null);
            }
        }
        else
        {
            //CASE 1.2: Right controller is null
            SetSelectedNodeRight(null);
        }
    }

    /// <summary>
    /// Handle logic for when left controller is hover over mindmap node
    /// </summary>
    private void HandleSelectedNodeForLeftController()
    {
        if (leftController != null)
        {
            Collider[] hitObjectsArray = Physics.OverlapSphere(leftController.transform.position, maxDistance, selectableLayerMask);
            //CASE 1.1: Left controller is not null
            if (hitObjectsArray.Length > 0)
            {
                //CASE 2.1: Left controller cast hit something
                Transform closestObjectHit = GetClosestObject(hitObjectsArray, leftController);
                if (closestObjectHit.TryGetComponent(out MindmapNode node))
                {
                    //CASE 3.1: Successfully detect a mindmap node
                    if (node != this.selectedNodeLeft)
                    {
                        SetSelectedNodeLeft(node);
                    }
                }
                else
                {
                    //CASE 3.2: Fail to detect a mindmap node
                    SetSelectedNodeLeft(null);
                }
            }
            else
            {
                //CASE 2.2: Left controller hit nothing
                SetSelectedNodeLeft(null);
            }
        }
        else
        {
            //CASE 1.2: Left controller is null
            SetSelectedNodeLeft(null);
        }
    }


    /// <summary>
    /// Setter for current selected node on the right controller
    /// </summary>
    /// <param name="mindmapNode">The mindmap node</param>
    private void SetSelectedNodeRight(MindmapNode mindmapNode)
    {
        this.selectedNodeRight = mindmapNode;
        OnSelectedMindmapNodeChanged?.Invoke(this, new OnSelectedMindmapNodeChangedEventArgs
        {
            selectedMindmapNode = this.selectedNodeRight,
        });
    }

    /// <summary>
    /// Setter for current selected node on the left controller
    /// </summary>
    /// <param name="mindmapNode">The mindmap node</param>
    private void SetSelectedNodeLeft(MindmapNode mindmapNode)
    {
        this.selectedNodeLeft = mindmapNode;
        OnSelectedMindmapNodeChanged?.Invoke(this, new OnSelectedMindmapNodeChangedEventArgs
        {
            selectedMindmapNode = this.selectedNodeLeft,
        });
    }

    /// <summary>
    /// Getter for selected node of the right controller
    /// </summary>
    /// <returns>The selected node of the right controller</returns>
    public MindmapNode GetSelectedNodeRight()
    {
        return this.selectedNodeRight;
    }

    /// <summary>
    /// Getter for selected node of the left controller
    /// </summary>
    /// <returns>The selected node of the left controller</returns>
    public MindmapNode GetSelectedNodeLeft()
    {
        return this.selectedNodeLeft;
    }

    /// <summary>
    /// Get closest object to an origin point in space
    /// </summary>
    /// <param name="objects">The array of colliders</param>
    /// <param name="origin">The origin</param>
    /// <returns>The closest object</returns>
    public Transform GetClosestObject(Collider[] objects, GameObject origin)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = origin.transform.position;
        foreach (Collider potentialTarget in objects)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.transform;
            }
        }

        return bestTarget;

    }
    #endregion
}