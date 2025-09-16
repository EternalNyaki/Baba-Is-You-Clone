using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : Singleton<GameEventManager>
{
    public event System.EventHandler<InputEventArgs> playerInputEvent;
    public event System.EventHandler<CellEnteredEventArgs> cellEnteredEvent;
    public event System.EventHandler<ObjectDestroyedEventArgs> objectDestroyedEvent;


    // Update is called once per frame
    void Update()
    {
        InputEventArgs args = new InputEventArgs();

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            args.KeyCode = KeyCode.UpArrow;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            args.KeyCode = KeyCode.RightArrow;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            args.KeyCode = KeyCode.DownArrow;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            args.KeyCode = KeyCode.LeftArrow;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            args.KeyCode = KeyCode.Space;
        }

        if (args.KeyCode != default)
        {
            OnPlayerInputEvent(args);
        }
    }

    private void OnPlayerInputEvent(InputEventArgs e)
    {
        playerInputEvent?.Invoke(this, e);
    }

    private void OnCellEnteredEvent(CellEnteredEventArgs e)
    {
        cellEnteredEvent?.Invoke(this, e);
    }

    private void OnObjectDestroyedEvent(ObjectDestroyedEventArgs e)
    {
        objectDestroyedEvent?.Invoke(this, e);
    }

    public void NotifyCellEntered(GridObject gridObject, Vector2Int position)
    {
        CellEnteredEventArgs args = new CellEnteredEventArgs()
        {
            GridObject = gridObject,
            Position = position
        };

        OnCellEnteredEvent(args);
    }

    public void NotifyObjectDestruction(GameObject gameObject)
    {
        ObjectDestroyedEventArgs args = new ObjectDestroyedEventArgs()
        {
            Object = gameObject
        };

        OnObjectDestroyedEvent(args);
    }
}

public class InputEventArgs : System.EventArgs
{
    public KeyCode KeyCode { get; set; }
}

public class CellEnteredEventArgs : System.EventArgs
{
    public GridObject GridObject { get; set; }
    public Vector2Int Position { get; set; }
}

public class ObjectDestroyedEventArgs : System.EventArgs
{
    public GameObject Object { get; set; }
}