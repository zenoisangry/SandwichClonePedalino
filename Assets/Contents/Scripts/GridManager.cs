using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public int gridSize = 4;
    private GameObject[,] grid;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new GameObject[gridSize, gridSize];
        float gridYOffset = 1.0f;

        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 position = new Vector3(i * 1.0f, gridYOffset - j * 1.0f, 0);
                grid[i, j] = Instantiate(cellPrefab, position, Quaternion.identity);
                grid[i, j].name = $"Cell {i},{j}";
            }
        }
    }

    public Vector3 GetEmptyCellPosition()
    {
        return grid[0, 0].transform.position;
    }
}