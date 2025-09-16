using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ObjectProperty
{
    public System.Action<GridObject, System.EventHandler> applyPropertyDelegate;
    public System.Action<GridObject, System.EventHandler> removePropertyDelegate;
    public System.Action<GridObject> propertyDelegate;
}

public struct ObjectProperty<TEventArgs>
{
    public System.Action<GridObject, System.EventHandler<TEventArgs>> applyPropertyDelegate;
    public System.Action<GridObject, System.EventHandler<TEventArgs>> removePropertyDelegate;
    public System.Action<GridObject, TEventArgs> propertyDelegate;
}
