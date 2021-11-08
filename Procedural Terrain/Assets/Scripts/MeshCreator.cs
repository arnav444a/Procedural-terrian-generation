using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    Vector3[] vertices;
    public TerrainGen terrainGen;
    int squareEdge;
    Mesh mesh;
    private void Start()
    {
        vertices = new Vector3[terrainGen.startX * terrainGen.startY];
        Mesh mesh = new Mesh();
        mesh.vertices = CreateVertices(vertices);
        GetComponent<MeshFilter>().mesh = mesh;
        mesh = GetComponent<MeshFilter>().mesh;
        squareEdge = Mathf.RoundToInt(mesh.vertices[1].x - mesh.vertices[0].x);

    }
    Vector3[] CreateVertices(Vector3[] vertices)
    {
        int k = 0;
        for (int i = 0; i < terrainGen.startX ; i++)
        {
            for (int j = 0; j < terrainGen.startY; j++)
            {
                vertices.SetValue(new Vector3(i, j, 0), k);
                k++;
            }
        }
        return vertices;
    }
    
}
