using System;
using UnityEngine;

public class MindmapLogicManager : MonoBehaviour
{
    #region Events
    public event EventHandler<OnSelectedMindmapNodeChangedEventArgs> OnSelectedMindmapNodeChanged;
    public event EventHandler<OnOpenCanvasButtonClickedEventArgs> OnOpenCanvasButtonClicked;
    #endregion

    #region Event Arguments Type
    public class OnSelectedMindmapNodeChangedEventArgs : EventArgs
    {
        public MindmapNode selectedMindmapNodeLeft;
        public MindmapNode selectedMindmapNodeRight;
    }
    public class OnOpenCanvasButtonClickedEventArgs : EventArgs
    {
        public MindmapNode mindmapNode;
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
    /// Get the grab movement to make logic
    /// </summary>
    [SerializeField] private GameObject grabMovementObject;

    /// <summary>
    /// Get the canvas properties for prefabs
    /// </summary>
    [SerializeField] private GameObject canvasProperties;

    /// <summary>
    /// Get the canvas properties for prefabs
    /// </summary>
    [SerializeField] private AudioSource audioSourceGameObject;

    /// <summary>
    /// GetGameObjectSpawner
    /// </summary>
    [SerializeField] private GameObject spawnerObject;


    /// <summary>
    /// The selected/hovered mindmap node for the right controller
    /// </summary>
    private MindmapNode selectedNodeRight;

    /// <summary>
    /// The selected/hovered mindmap node for the left controller
    /// </summary>  
    private MindmapNode selectedNodeLeft;


    public float distanceInFront = 0.1f;

    #endregion

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        HandleSelectedNodeForRightController();
        HandleSelectedNodeForLeftController();

        ManageLeftHandInteraction();
        ManageRightHandInteraction();
    }
    private void ManageLeftHandInteraction()
    {
        if (this.selectedNodeLeft != null)
        {
            grabMovementObject.GetComponent<GrabMoveMindmapLHand>().enabled = false;
            spawnerObject.GetComponent<TriggerShapeSpawner>().enabled = false;
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                OnOpenCanvasButtonClicked?.Invoke(this, new OnOpenCanvasButtonClickedEventArgs
                {
                    mindmapNode = this.selectedNodeLeft
                });
            }
        }
        else
        {
            grabMovementObject.GetComponent<GrabMoveMindmapLHand>().enabled = true;
            spawnerObject.GetComponent<TriggerShapeSpawner>().enabled = true;
        }
    }

    private void ManageRightHandInteraction()
    {
        if (this.selectedNodeRight != null)
        {
            grabMovementObject.GetComponent<GrabMoveMindmap>().enabled = false;
            spawnerObject.GetComponent<TriggerShapeSpawnerRight>().enabled = false;
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                OnOpenCanvasButtonClicked?.Invoke(this, new OnOpenCanvasButtonClickedEventArgs
                {
                    mindmapNode = this.selectedNodeRight
                });
            }
        }
        else
        {
            grabMovementObject.GetComponent<GrabMoveMindmap>().enabled = true;
            spawnerObject.GetComponent<TriggerShapeSpawnerRight>().enabled = true;
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
                        bool isGrabbing = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);
                        if (isGrabbing && this.selectedNodeRight != null)
                        {
                            OnSelectedMindmapNodeChanged?.Invoke(this, new OnSelectedMindmapNodeChangedEventArgs
                            {
                                selectedMindmapNodeRight = this.selectedNodeRight,
                                selectedMindmapNodeLeft = this.selectedNodeLeft,
                            });
                        }
                        else
                        {
                            SetSelectedNodeRight(node);
                        }
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
                        bool isGrabbing = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
                        if (isGrabbing && this.selectedNodeLeft != null)
                        {
                            OnSelectedMindmapNodeChanged?.Invoke(this, new OnSelectedMindmapNodeChangedEventArgs
                            {
                                selectedMindmapNodeRight = this.selectedNodeRight,
                                selectedMindmapNodeLeft = this.selectedNodeLeft,
                            });
                        }
                        else
                        {
                            SetSelectedNodeLeft(node);
                        }
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
            selectedMindmapNodeRight = this.selectedNodeRight,
            selectedMindmapNodeLeft = this.selectedNodeLeft,
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
            selectedMindmapNodeRight = this.selectedNodeRight,
            selectedMindmapNodeLeft = this.selectedNodeLeft,
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
    public void CloseCanvas()
    {
        Debug.Log("Closing Canvas");
        grabMovementObject.SetActive(true);
        grabMovementObject.GetComponent<GrabMoveMindmap>().enabled = true;
        grabMovementObject.GetComponent<GrabMoveMindmapLHand>().enabled = true;
    }
    #endregion
}