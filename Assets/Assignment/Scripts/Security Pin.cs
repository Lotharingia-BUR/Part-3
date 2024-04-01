using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityPin : Pin
{
    public List<GameObject> barrels;

    public override void OnTop(Collision2D collision)
    {
        if (collision.transform.position.y > height + collision.transform.localScale.y)
        {
            foreach (var i in barrels)
            {
                i.SendMessage("Fall");
            }
        }
    }
}
