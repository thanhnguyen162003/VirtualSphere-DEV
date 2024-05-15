using System;
using UnityEngine;

public class MindmapNode : MonoBehaviour
{
    /// <summary>
    /// The mindmap node GUID
    /// </summary>
    private string gUID;
    /// <summary>
    /// Get node GUID
    /// </summary>
    /// <returns>Node's GUID</returns>
    public string GetMindmapNodeGUID()
    {
        return gUID;
    }
    /// <summary>
    /// Set mind map node GUID to a string of your choice
    /// </summary>
    /// <param name="gUID">the string</param>
    public void SetMindmapNodeGUID(string gUID)
    {
        this.gUID = gUID;
    }
    /// <summary>
    /// Set mindmap node GUID to a System's GUID
    /// </summary>
    /// <param name="gUID">the GUID></param>
    public void SetMindmapNodeGUID(Guid gUID)
    {
        this.gUID = gUID.ToString();
    }

    /// <summary>
    /// Auto create a GUID and set it to node
    /// </summary>
    public void AutoSetMindmapNodeGUID()
    {
        this.gUID = Guid.NewGuid().ToString();
    }
}
