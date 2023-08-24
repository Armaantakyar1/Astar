using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] MeshFilter filter;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Texture2D heightMap;
    [SerializeField] int height;
    [SerializeField] int Xvertices;
    [SerializeField] int Zvertices;
    public int totalVertices;
    Vector3[] vertices;
    int[] indecies;
    int totalIndecies;

    void Start()
    {
        filter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material.color = Color.black;

        totalVertices = Xvertices * Zvertices;
        vertices = new Vector3[totalVertices];
        for (int z = 0; z < Zvertices; z++)
        {
            for (int x = 0; x < Xvertices; x++)
            {
                Color pixel = heightMap.GetPixel(x, z);
                int index = x + z * Xvertices;
                vertices[index] = new Vector3(x, pixel.r * height, z);
            }
        }

        totalIndecies = (Xvertices - 1) * (Zvertices - 1) * 3 * 2;
        indecies = new int[totalIndecies];
        int currentIndex = 0;
        int p = 0;
        for (int z = 0; z < Zvertices - 1; z++)
        {
            for (int x = 0; x < Xvertices - 1; x++)
            {
                indecies[p + 0] = currentIndex;
                indecies[p + 1] = currentIndex + Xvertices;
                indecies[p + 2] = currentIndex + Xvertices + 1;
                indecies[p + 3] = currentIndex + Xvertices + 1;
                indecies[p + 4] = currentIndex + 1;
                indecies[p + 5] = currentIndex;
                currentIndex++;
                p += 6;
            }
            currentIndex++;
        }
        filter.mesh.vertices = vertices;
        filter.mesh.triangles = indecies;
    }
    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;

        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
