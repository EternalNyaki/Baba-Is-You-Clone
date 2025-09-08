using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbTextObject : RuleTextObject
{

    protected override void Initialize()
    {
        base.Initialize();

        GetComponent<SpriteRenderer>().color = Color.gray;
    }

    protected override void LogicUpdate()
    {
        base.LogicUpdate();

        //HACK: I can already tell this isn't gonna work when it comes to actually applying rules, so this is just from testing adjacency detection

        //Check top and left for object text
        ObjectTextObject topText = WorldGrid.Instance.GetObjectAtPosition<ObjectTextObject>(position.x, position.y + 1);
        ObjectTextObject leftText = WorldGrid.Instance.GetObjectAtPosition<ObjectTextObject>(position.x - 1, position.y);

        //Check bottom and right for property text
        PropertyTextObject bottomText = WorldGrid.Instance.GetObjectAtPosition<PropertyTextObject>(position.x, position.y - 1);
        PropertyTextObject rightText = WorldGrid.Instance.GetObjectAtPosition<PropertyTextObject>(position.x + 1, position.y);

        if ((topText != null && bottomText != null) || (leftText != null && rightText != null))
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}
