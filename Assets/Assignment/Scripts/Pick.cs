using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 newPos = new Vector2(-8, -2);
    bool isClicked;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            StopCoroutine(ResetPick());
            StartCoroutine(Picking());

        } else
        {
            newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StopCoroutine(Picking());
            StartCoroutine(ResetPick());
        }

        if (newPos.x > 4.5f)
        {
            rb.MovePosition(new Vector2(-4.5f, -2)); 
        } else if (newPos.x < -4.5f)
        {
            rb.MovePosition(new Vector2(-13.5f, -2));
        } 
        else
        {
            rb.MovePosition(newPos * Vector2.right + new Vector2(-9, -2));
        }

        
    }

    IEnumerator Picking()
    {
        while(transform.rotation.z <= 0.085f)
        {
            transform.Rotate(new Vector3(0, 0, 0.1f));
        }
        yield return null;
    }

    IEnumerator ResetPick()
    {
        while (transform.rotation.z >= 0f)
        {
            transform.Rotate(new Vector3(0, 0, -0.1f));
        }
        yield return null;
    }
}
