using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    Rigidbody2D rb;
    bool isClicked;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isClicked)
        {
            transform.Translate(Vector3.up * 1 * Time.deltaTime);
        }
        else if(!isClicked && transform.position.y >= -2)
        {
            transform.Translate(Vector3.down * 1 * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        isClicked = true;
    }

    private void OnMouseUp()
    {
        isClicked = false;
    }
}
