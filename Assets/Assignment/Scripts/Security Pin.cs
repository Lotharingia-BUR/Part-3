using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityPin : Pin
{
    public List<GameObject> barrels;

    public override void OnTop(Collision2D collision)
    {
        for (int i = 0; i < barrels.Capacity; i++)
        {
            /*Debug.Log(i);*/
        }
    }
}
