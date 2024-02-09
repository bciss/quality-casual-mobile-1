using System.Security.Cryptography;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType {unknown, start, goal};
public class LevelManager : MonoBehaviour
{
    public Vector2Int gridSize;
    public Vector2Int startPostion;
    public Vector2Int goalPosition;
    public GameObject unknownTilePrefab;
    public float cellSize = 1f;
    private GameObject[,] gridArray;
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
        ChangeTile(startPostion.x, startPostion.y, TileType.start);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {
        gridArray = new GameObject[gridSize.x, gridSize.y];
        // Calculate the offset to the center of the grid
        Vector3 centerOffset = new Vector3((gridSize.x - 1) * cellSize / 2f, (gridSize.y - 1) * cellSize / 2f, 0f);

        // Calculate the starting position for the grid
        Vector3 startPos = transform.position - centerOffset;

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                // Calculate the position for each grid cell relative to the starting position
                Vector3 position = startPos + new Vector3(x * cellSize, y * cellSize, 0f);

                // Instantiate the prefab at the calculated position
                GameObject instantiatedPrefab = Instantiate(unknownTilePrefab, position, Quaternion.identity);
                gridArray[x, y] = instantiatedPrefab;
            }
        }
    }

    void ChangeTile(int xIndex, int yIndex, TileType tileType)
    {
        if (gridArray[xIndex, yIndex] != null)
        {
            switch(tileType)
            {
                case TileType.unknown:
                //
                break;
                case TileType.start:
                gridArray[xIndex, yIndex].GetComponent<Renderer>().material.color = Color.blue;
                break;
                case TileType.goal:
                //
                break;
            }
        }
    }
}
