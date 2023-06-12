using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Astar : MonoBehaviour
{
    Node startNode;
    Node goalNode;
    [SerializeField] List<Node> neighbors = new List<Node>();
    [SerializeField] int xsize;
    [SerializeField] int zsize;
    [SerializeField]GridMaker grid;

    void Start()
    {
        xsize = grid.sizeX;
        zsize = grid.sizeZ;
        startNode = grid.GetNode(new Vector3Int(0, 0, 0));
        startNode.cube.GetComponent<MeshRenderer>().material.color = new Color(0, 0.35f, 1); 
        goalNode = grid.GetNode(new Vector3Int(3, 0, 2));
        goalNode.cube.GetComponent<MeshRenderer>().material.color = new Color(0.25f, 0, 1);
        AddNeighbors(startNode);
    } 

    void AddNeighbors(Node currentNode)
    {


        for (int x = currentNode.position.x -1 ; x < currentNode.position.x + 2; x++)
        {
            if (x < 0 || x > xsize)
            {
                continue;
            }
            for (int z = currentNode.position.z -1; z < currentNode.position.z+2; z++)
            {
                if (z < 0 || z > zsize)
                {
                    continue;
                }
                if (x == currentNode.position.x && z == currentNode.position.z)
                {
                    z++;
                }
                Node position = grid.GetNode(new Vector3Int(x, 0, z));
                neighbors.Add(position);
                position.cube.GetComponent<MeshRenderer>().material.color = new Color(1, 0.6f, 0);
            }
        }
    }
    
}
