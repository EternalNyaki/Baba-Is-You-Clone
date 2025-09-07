using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Grid Player Controller
/// Temporary class for testing grid movement
/// </summary>
public class GridPlayerController : GridObject
{
    protected override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            WorldGrid.Instance.MoveGridObject(this, Direction.Up);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            WorldGrid.Instance.MoveGridObject(this, Direction.Right);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            WorldGrid.Instance.MoveGridObject(this, Direction.Down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            WorldGrid.Instance.MoveGridObject(this, Direction.Left);
        }
    }
}
