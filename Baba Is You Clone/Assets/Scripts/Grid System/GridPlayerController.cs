using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Grid Player Controller
/// Temporary class for testing grid movement
/// </summary>
[System.Obsolete]
public class GridPlayerController : GridObject
{
    protected override void Initialize()
    {
        base.Initialize();

        GameEventManager.Instance.playerInputEvent += Move;
    }

    private void Move(object sender, InputEventArgs e)
    {
        switch (e.KeyCode)
        {
            case KeyCode.UpArrow:
                WorldGrid.Instance.MoveGridObject(this, Direction.Up);
                break;

            case KeyCode.RightArrow:
                WorldGrid.Instance.MoveGridObject(this, Direction.Right);
                break;

            case KeyCode.DownArrow:
                WorldGrid.Instance.MoveGridObject(this, Direction.Down);
                break;

            case KeyCode.LeftArrow:
                WorldGrid.Instance.MoveGridObject(this, Direction.Left);
                break;
        }
    }
}
