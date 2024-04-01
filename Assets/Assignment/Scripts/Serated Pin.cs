using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeratedPin : Pin
{
    public List<GameObject> edges;
    public List<GameObject> blocks;
    private int edgeNum = 0;
    private int cycle = 0;

    public override void OnTop(Collision2D collision)
    {
        seratedEdge();
    }

    public override void Fall()
    {
        base.Fall();
        seratedEdge();
    }

    private void seratedEdge()
    {
        if (!Input.GetMouseButton(0))
        {
            edgeNum = 0;
            cycle = 0;

            foreach (var i in edges)
            {
                Debug.Log(i.transform.position.y + " > " + (height + 0.6f) + " " + i.name);
                if (i.transform.position.y > (height + 0.6f))
                {
                    edgeNum++;
                }
            }
            Debug.Log(edgeNum);
            foreach (var i in blocks)
            {
                if (cycle >= edgeNum)
                {
                    i.SetActive(true);
                    return;
                }
                cycle++;
                i.SetActive(false);
            }
        }
    }
}
