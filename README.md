![image](https://github.com/huscongao1692003/VirtualSphere-DEV/assets/72685335/b4dad726-d166-4f48-9833-a0a2ee24fb09)

//node store
{
  workspaceId: "lkasjdklajsdkljl",
  workspaceName: "name",
  createdAt: datetime, 
  createdBy: "name",
  updatedAt: time, 
  nodes: [
    {
      nodeId: "uniqueId1", 
      name: "Node 1",
      position: {
        x: 10,
        y: 20,
        z: 5
      },
      bodyText: "This is the description of the node",
      shape: "sphere", 
      color: "#FF0000", 
      image: "image_url.jpg", 
      parentId: null, // Top-level nodes have no parent
      children: ["uniqueId2", "uniqueId5"] // Array of nodeIds of this node's children
    },
    // ... more nodes
  ]
}
//
