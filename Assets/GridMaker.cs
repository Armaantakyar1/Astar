using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    [SerializeField] GameObject cube;
    public int sizeX = 5;
    public int sizeZ = 5;

    [SerializeField] int space = 1;
    public Node[] nodes;

    void Start()
    {
        nodes = new Node[sizeX * sizeZ];
        Generate();
        
    }
    void Generate()
    {
        for(int z = 0; z< sizeZ; z++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                int i = x + z * sizeX;
                Vector3Int position = new Vector3Int(x * space, 0, z * space);

                GameObject we = Instantiate(cube, position, Quaternion.identity);
                nodes[i] = new Node(position);
                
                nodes[i].cube = we;
            }
        }
    }

    public Node GetNode(Vector3Int cords)
    {

        int i = cords.x + cords.z * sizeX;
        
        return nodes[i];

    }

}
