using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}

/// <summary>
/// Grid Object class
/// GameObject with a position and direction on a 2D grid
/// </summary>
public class GridObject : MonoBehaviour
{
    public Vector2Int position;
    public Direction facingDirection;

    //Event to be called whenever another grid object enters the same cell
    public event System.EventHandler<GridObject> cellEnteredEvent;

    void Start()
    {
        WorldGrid.Instance.AddObjectToGrid(this);

        transform.position = WorldGrid.Instance.GridToWorldPosition(position);

        Initialize();
    }

    /// <summary>
    /// Override instead of using Start or Awake when inheriting
    /// </summary>
    protected virtual void Initialize() { }

    void Update()
    {
        transform.position = WorldGrid.Instance.GridToWorldPosition(position);

        LogicUpdate();
    }

    /// <summary>
    /// Override instead of using Update when inheriting
    /// </summary>
    protected virtual void LogicUpdate() { }

    public void OnCellEntered(object sender, GridObject source)
    {
        cellEnteredEvent?.Invoke(sender, source);
    }
}
