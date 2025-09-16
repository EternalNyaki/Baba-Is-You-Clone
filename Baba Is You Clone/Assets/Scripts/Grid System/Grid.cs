using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Grid class
/// Stores a 2D grid of values and contains method for converting from grid space to relative world space
/// </summary>
/// <typeparam name="T"> The type of value to be stored in the grid </typeparam>
public class Grid<T> : IEnumerable
{
    //Grid dimensions
    public int width, height;
    private float m_cellSize; //Grid only supports square cells

    private T[,] m_values;

    //Grid center relative to the bottom left corner, in units
    private Vector2 gridCenter;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        m_cellSize = cellSize;

        gridCenter = new Vector2(width, height) * cellSize / 2;

        m_values = new T[width, height];
    }

    /// <summary>
    /// Gets the world position of the cell at position (x, y) relative to the center of the grid
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns> Position in units relative to the center of the grid </returns>
    public Vector2 GetRelativePosition(int x, int y)
    {
        return new Vector2(x, y) * m_cellSize - gridCenter;
    }

    /// <summary>
    /// Sets the value of the cell at the given position
    /// </summary>
    /// <param name="x"> X index of the cell </param>
    /// <param name="y"> Y index of the cell </param>
    /// <param name="value"> Value to set </param>
    public void SetCellValue(int x, int y, T value)
    {
        m_values[x, y] = value;
    }

    /// <summary>
    /// Gets the value of the cell at the given position
    /// </summary>
    /// <param name="x"> X index of the cell </param>
    /// <param name="y"> Y index of the cell </param>
    /// <returns> The value of the cell </returns>
    public T GetCellValue(int x, int y)
    {
        return m_values[x, y];
    }

    public T this[int x, int y]
    {
        get => m_values[x, y];
        set => m_values[x, y] = value;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public GridEnum<T> GetEnumerator()
    {
        return new GridEnum<T>(m_values);
    }
}

public class GridEnum<T> : IEnumerator
{
    public T[,] gridValues;

    int position = -1;

    public GridEnum(T[,] values)
    {
        gridValues = values;
    }

    public bool MoveNext()
    {
        position++;
        return position < gridValues.Length;
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public T Current
    {
        get
        {
            try
            {
                return gridValues[position / gridValues.GetLength(1), position % gridValues.GetLength(1)];
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.InvalidOperationException();
            }
        }
    }
}
