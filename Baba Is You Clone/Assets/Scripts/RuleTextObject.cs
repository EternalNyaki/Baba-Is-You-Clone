using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleTextObject : GridObject
{
    protected override void Initialize()
    {
        base.Initialize();

        cellEnteredEvent += (object sender, GridObject gObj) =>
            WorldGrid.Instance.MoveGridObject(this, gObj.facingDirection);
    }
}
