using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MindmapNodeVisual : MonoBehaviour
{
    /// <summary>
    /// The mindmap node prefab (the OUTER MOST PARENT OBJECT)
    /// </summary>
    [SerializeField] private MindmapNode mindmapNode;
    private void Awake()
    {
        #region Event Register
        MindmapLogicManager.Instance.OnSelectedMindmapNodeChanged += MindmapLogicManager_OnSelectedMindmapNodeChanged;
        #endregion
    }

    private void OnDestroy()
    {
        #region Event De-register
        MindmapLogicManager.Instance.OnSelectedMindmapNodeChanged -= MindmapLogicManager_OnSelectedMindmapNodeChanged;
        #endregion
    }

    #region Event Methods
    private void MindmapLogicManager_OnSelectedMindmapNodeChanged(object sender, MindmapLogicManager.OnSelectedMindmapNodeChangedEventArgs e)
    {
        if (e.selectedMindmapNode == this.mindmapNode)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    #endregion

    #region Methods
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
