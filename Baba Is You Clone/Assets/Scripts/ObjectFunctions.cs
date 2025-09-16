using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectFunctions
{
    public static void Move(GridObject sender, KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.UpArrow:
                WorldGrid.Instance.MoveGridObject(sender, Direction.Up);
                break;

            case KeyCode.RightArrow:
                WorldGrid.Instance.MoveGridObject(sender, Direction.Right);
                break;

            case KeyCode.DownArrow:
                WorldGrid.Instance.MoveGridObject(sender, Direction.Down);
                break;

            case KeyCode.LeftArrow:
                WorldGrid.Instance.MoveGridObject(sender, Direction.Left);
                break;
        }
    }
}
