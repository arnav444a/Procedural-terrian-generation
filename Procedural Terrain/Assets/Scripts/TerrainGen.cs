using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainGen : MonoBehaviour
{
    public Terrain terrainMesh;
    Texture2D terrainTex;
    public int startX=128, startY=128;
    public float offsetX, offsetY,primaryOffsetX,primaryOffsetY,resolution;
    public Image image;
    public GameObject terrainObj;
    int depth = 20;
    public int scale =20;
    float startTime;

    private void Start()
    {
        primaryOffsetX = Random.Range(0, 99999);
        primaryOffsetY = Random.Range(0, 99999);

        Mesh mesh = new Mesh();
        terrainTex = new Texture2D(128, 128);
        AssignColorToTexture(terrainTex);
        image.GetComponent<Image>().material.mainTexture = terrainTex;

    }
    public void AssignColorToTexture(Texture2D terrain)
    {
        for (int i = 0; i < startX; i++)
        {
            for (int j = 0; j < startY; j++)
            {
                float sample = Mathf.PerlinNoise( (i +offsetX )/ startX * resolution, (j +offsetY)/ startY * resolution);
                Color pixelColor = new Color(sample,sample,sample, 1);
                terrain.SetPixel(i, j, pixelColor);
            }
        }
        terrain.Apply();

    }
    private void Update()
    {
        AssignColorToTexture(terrainTex);
        image.material.mainTexture = terrainTex;
        if (Time.time - startTime > 0.1f)
        {
            startTime = Time.time;
            terrainMesh.terrainData = HeightConverter(terrainMesh.terrainData);
        }
    }
    TerrainData HeightConverter(TerrainData terrainData)
    {
        terrainData.heightmapResolution = startX + 1;
        terrainData.size = new Vector3(startX, depth,startY);
        terrainData.SetHeights(0, 0, HeightCalculator());
        return terrainData;
    }
    float[,] HeightCalculator()
    {
        float[,] heights = new float[startX, startY];
        for (int i = 0; i < startX; i++)
        {
            for (int j = 0; j < startY; j++)
            {
                heights[i, j] = Calculateheight(i,j);
            }
        }
        return heights;
    }
    float Calculateheight(int i, int j)
    {
        float xCord =(float) (i + primaryOffsetX + offsetX)/ startX * resolution;
        float yCord =(float) (j + primaryOffsetY + offsetY)/ startY * resolution;
        return Mathf.PerlinNoise(xCord, yCord);
    }
}
