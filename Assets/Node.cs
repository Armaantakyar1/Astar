using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public GameObject cube ;
    int Gcost;
    int Hcost;
    public Node parent;
    public int Fcost
    {
        get
        {
            return Gcost+ Hcost;
        }
    }

    public Vector3Int position
    {
        get;
        private set;
    }

    public Node (Vector3Int Inposition)
    {
        position = Inposition;
    }
}
