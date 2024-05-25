using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class MindmapNodeVisual : MonoBehaviour
{
    #region Properties
    private float distanceInFront = 0.2f;
    /// <summary>
    /// The mindmap node prefab (the OUTER MOST PARENT OBJECT)
    /// </summary>
    [SerializeField] private MindmapNode mindmapNode;
    [SerializeField] private GameObject canvasProperties;
    #endregion
    private void Awake()
    {
        #region Event Register
        MindmapLogicManager.Instance.OnSelectedMindmapNodeChanged += MindmapLogicManager_OnSelectedMindmapNodeChanged;
        MindmapLogicManager.Instance.OnOpenCanvasButtonClicked += MindmapLogicManager_OnOpenCanvasButtonClicked;
        #endregion
    }

    private void OnDestroy()
    {
        #region Event De-register
        MindmapLogicManager.Instance.OnSelectedMindmapNodeChanged -= MindmapLogicManager_OnSelectedMindmapNodeChanged;
        MindmapLogicManager.Instance.OnOpenCanvasButtonClicked -= MindmapLogicManager_OnOpenCanvasButtonClicked;
        #endregion
    }

    #region Event Methods
    private void MindmapLogicManager_OnSelectedMindmapNodeChanged(object sender, MindmapLogicManager.OnSelectedMindmapNodeChangedEventArgs e)
    {
        if (e.selectedMindmapNodeRight == this.mindmapNode || e.selectedMindmapNodeLeft == this.mindmapNode)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void MindmapLogicManager_OnOpenCanvasButtonClicked(object sender, MindmapLogicManager.OnOpenCanvasButtonClickedEventArgs e)
    {
        var currentCanvas = gameObject.GetComponentInChildren<CanvasPrefabPropertiesManager>();
        if (e.mindmapNode == this.mindmapNode)
        {
            if (currentCanvas == null)
            {
                CreateCanvas();
            }
            else
            {
                DestroyCanvas();
            }
        }
        else
        {
            if (currentCanvas != null)
            {
                DestroyCanvas();
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Create a canvas 
    /// </summary>
    private void CreateCanvas()
    {
        var currentCanvas = gameObject.GetComponentInChildren<CanvasPrefabPropertiesManager>();
        if (currentCanvas == null)
        {
            Vector3 spawnPosition = gameObject.transform.position + gameObject.transform.right * distanceInFront;
            Instantiate(canvasProperties, spawnPosition, gameObject.transform.rotation, gameObject.transform);
        }
    }

    /// <summary>
    /// Destroy canvas
    /// </summary>
    private void DestroyCanvas()
    {
        var currentCanvas = gameObject.GetComponentInChildren<CanvasPrefabPropertiesManager>();
        if (currentCanvas != null)
        {
            Destroy(currentCanvas.gameObject);
            MindmapLogicManager.Instance.CloseCanvas();
        }

    }
    /// <summary>
    /// Show outline
    /// </summary>
    private void Show()
    {
        Outline outlineComponent = this.mindmapNode.GetComponent<Outline>();
        if (outlineComponent == null)
        {
            outlineComponent = this.mindmapNode.AddComponent<Outline>();
            outlineComponent.enabled = true;
            outlineComponent.OutlineColor = Color.white;
            outlineComponent.OutlineWidth = 7.0f;
        }
        else
        {
            outlineComponent.enabled = true;
        }
    }

    /// <summary>
    /// Hide outline
    /// </summary>
    private void Hide()
    {
        Outline outlineComponent = this.mindmapNode.GetComponent<Outline>();
        if (outlineComponent != null)
        {
            outlineComponent.enabled = false;
        }
    }
    #endregion

}
