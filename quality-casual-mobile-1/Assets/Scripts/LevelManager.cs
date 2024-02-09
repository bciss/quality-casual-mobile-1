using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Vector2Int gridSize;
    public GameObject unknownTilePrefab;
    public float cellSize = 1f;
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {
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
                Instantiate(unknownTilePrefab, position, Quaternion.identity);
            }
        }
    }
}
