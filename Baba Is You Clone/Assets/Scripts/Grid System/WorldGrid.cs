using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// World Grid class
/// Represents a grid in the world and manages all objects within the grid
/// </summary>
public class WorldGrid : Singleton<WorldGrid>
{
    //Grid dimensions
    public int width;
    public int height;

    //Temp object for grid visuals
    public GameObject gridCellPrefab;

    //The grid
    private Grid<List<GridObject>> m_grid;

    protected override void Initialize()
    {
        base.Initialize();

        m_grid = new Grid<List<GridObject>>(width, height, 1f);

        //Initialize grid visuals
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Instantiate(gridCellPrefab, m_grid.GetRelativePosition(j, i), Quaternion.identity, transform);
                m_grid[j, i] = new List<GridObject>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Adds a grid object to the values of the grid
    /// Should be called by every grid object as part of their initialization
    /// </summary>
    /// <param name="gridObject"></param>
    public void AddObjectToGrid(GridObject gridObject)
    {
        m_grid.GetCellValue(gridObject.position.x, gridObject.position.y).Add(gridObject);
    }

    /// <summary>
    /// Move the given grid object in the given direction
    /// </summary>
    /// <param name="gridObject"></param>
    /// <param name="direction"></param>
    public void MoveGridObject(GridObject gridObject, Direction direction)
    {

        //Remove the object from the grid for while movement logic is being perfomed
        m_grid[gridObject.position.x, gridObject.position.y].Remove(gridObject);

        gridObject.facingDirection = direction;

        //Update object position
        switch (direction)
        {
            case Direction.Up:
                gridObject.position.y++;
                break;

            case Direction.Right:
                gridObject.position.x++;
                break;

            case Direction.Down:
                gridObject.position.y--;
                break;

            case Direction.Left:
                gridObject.position.x--;
                break;
        }
        gridObject.position = ConstrainPosition(gridObject.position);

        //Add the object back to the grid in the new position
        m_grid.GetCellValue(gridObject.position.x, gridObject.position.y).Add(gridObject);

        //Notify each object in the cell the object has moved into
        //Using a for loop instead of a foreach because objects in the list might
        //modify the list themselves during this execution
        List<GridObject> cellValue = m_grid[gridObject.position.x, gridObject.position.y];
        for (int i = 0; i < cellValue.Count; i++)
        {
            if (cellValue[i] != gridObject)
            {
                cellValue[i].OnCellEntered(this, gridObject);
            }
        }
    }

    /// <summary>
    /// Converts a grid index to a position in world space
    /// </summary>
    /// <param name="gridX"> X index in the grid </param>
    /// <param name="gridY"> Y index in the grid </param>
    /// <returns> Position in world space </returns>
    public Vector2 GridToWorldPosition(int gridX, int gridY)
    {
        return m_grid.GetRelativePosition(gridX, gridY);
    }

    /// <summary>
    /// Converts a grid index to a position in world space
    /// </summary>
    /// <param name="gridPosition"> Position in the grid </param>
    /// <returns> Position in world space </returns>
    public Vector2 GridToWorldPosition(Vector2Int gridPosition)
    {
        return m_grid.GetRelativePosition(gridPosition.x, gridPosition.y);
    }

    /// <summary>
    /// Constrains a position within the size of the grid
    /// </summary>
    /// <param name="position"> Unconstrained grid position </param>
    /// <returns> Constrained grid position </returns>
    public Vector2Int ConstrainPosition(Vector2Int position)
    {
        int x = Mathf.Clamp(position.x, 0, m_grid.width - 1);
        int y = Mathf.Clamp(position.y, 0, m_grid.height - 1);
        return new(x, y);
    }
}
