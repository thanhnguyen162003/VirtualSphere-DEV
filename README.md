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
       metadata: {     
          ... 
      } ,
      color: "#FF0000", 
      image: "image_url.jpg", 
      parentId: null, // Top-level nodes have no parent
      children: ["uniqueId2", "uniqueId5"] // Array of nodeIds of this node's children
    },
    // ... more nodes
  ]
}
//

example
{
  "workspaceId": "workspace-abc123",
  "workspaceName": "Project Brainstorm",
  "createdAt": "2024-05-07T10:30:00Z",
  "createdBy": "Alice",
  "updatedAt": "2024-05-07T12:15:00Z",
  "nodes": [
    {
      "nodeId": "node-1",
      "name": "Main Idea",
      "position": { "x": 50, "y": 80, "z": 0 },
      "bodyText": "The core concept of our project",
      "shape": "cube",
      "color": "#0080FF",
      "image": null,
      "parentId": null,  // This is a top-level node
      "children": ["node-2", "node-3"]
    },
    {
      "nodeId": "node-2",
      "name": "Supporting Idea 1",
      "position": { "x": 20, "y": 150, "z": 0 },
      "bodyText": "Elaborates on the main idea",
      "shape": "sphere",
      "color": "#FFFF00",
      "image": null,
      "parentId": "node-1", // Child of "Main Idea"
      "children": [] // Currently has no children 
    },
    {
      "nodeId": "node-3",
      "name": "Supporting Idea 2",
      "position": { "x": 90, "y": 150, "z": 0 },
      "bodyText": "Another aspect of the main idea",
      "shape": "cylinder",
      "color": "#00FF00",
      "image": "concept_diagram.png",
      "parentId": "node-1", // Child of "Main Idea"
      "children": ["node-4"]
    },
    {
      "nodeId": "node-4",
      "name": "Specific Detail",
      "position": { "x": 120, "y": 220, "z": 0 },
      "bodyText": "A detailed point",
      "shape": "sphere",
      "color": "#FF00FF",
      "image": null,
      "parentId": "node-3", // Child of "Supporting Idea 2"
      "children": []
    }
  ]
}

