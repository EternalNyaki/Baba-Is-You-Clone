using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropertyType
{
    None,
    You,
    Stop,
    Push,
    Win,
    Shut,
    Open,
    Defeat,
    Sink
}

public class PropertyTextObject : RuleTextObject
{
    private ObjectProperty<InputEventArgs> m_youProperty = new ObjectProperty<InputEventArgs>
    {
        applyPropertyDelegate = (GridObject t, System.EventHandler<InputEventArgs> p) =>
            GameEventManager.Instance.playerInputEvent += p,

        removePropertyDelegate = (GridObject t, System.EventHandler<InputEventArgs> p) =>
            GameEventManager.Instance.playerInputEvent -= p,

        propertyDelegate = (GridObject t, InputEventArgs e) => ObjectFunctions.Move(t, e.KeyCode)
    };

    private ObjectProperty m_stopProperty = new ObjectProperty
    {
        applyPropertyDelegate = (GridObject t, System.EventHandler p) =>
        {
            t.blockMovement += (GridObject other) => false;
        }
    };

    private ObjectProperty<CellEnteredEventArgs> m_pushProperty = new ObjectProperty<CellEnteredEventArgs>
    {
        applyPropertyDelegate = (GridObject t, System.EventHandler<CellEnteredEventArgs> p) => GameEventManager.Instance.cellEnteredEvent += p,

        removePropertyDelegate = (GridObject t, System.EventHandler<CellEnteredEventArgs> p) => GameEventManager.Instance.cellEnteredEvent += p,

        propertyDelegate = (GridObject t, CellEnteredEventArgs e) => WorldGrid.Instance.MoveGridObject(t, e.GridObject.facingDirection)
    };

    private ObjectProperty<CellEnteredEventArgs> m_winProperty = new ObjectProperty<CellEnteredEventArgs>
    {
        applyPropertyDelegate = (GridObject t, System.EventHandler<CellEnteredEventArgs> p) => GameEventManager.Instance.cellEnteredEvent += p,

        removePropertyDelegate = (GridObject t, System.EventHandler<CellEnteredEventArgs> p) => GameEventManager.Instance.cellEnteredEvent -= p,

        propertyDelegate = (GridObject t, CellEnteredEventArgs e) =>
        {
            //Win game logic
        }
    };

    private ObjectProperty m_shutProperty = new ObjectProperty
    {

    };

    private ObjectProperty m_openProperty = new ObjectProperty
    {

    };

    private ObjectProperty m_defeatProperty = new ObjectProperty
    {

    };


}
