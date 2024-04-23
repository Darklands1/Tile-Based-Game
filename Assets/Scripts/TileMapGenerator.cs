using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int mapWidth = 10;
    public int mapLength = 10;
    public float tileSize = 1f;

    Color[] randomColors = new Color[6];

    void Start()
    {
        GenerateRandomColors();
        GenerateMap();

        Vector3 randomSpawnPosition = new Vector3(Random.Range(0, mapWidth) * tileSize, 0f, Random.Range(0, mapLength) * tileSize);
        GameObject spawnPrefab = Instantiate(prefabToSpawn, randomSpawnPosition, Quaternion.identity);
    }

    void GenerateRandomColors()
    {
        for (int i = 0; i < 6; i++)
        {
            randomColors[i] = new Color(Random.value, Random.value, Random.value);
        }
    }

    void GenerateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapLength; z++)
            {
                Vector3 spawnPosition = new Vector3(x * tileSize, 0f, z * tileSize);
                GameObject newTile = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
                newTile.GetComponent<Renderer>().material.color = GetRandomColor();
            }
        }
    }

    Color GetRandomColor()
    {
        return randomColors[Random.Range(0, randomColors.Length)];
    }
}
