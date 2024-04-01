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
        rb.MovePosition(newPos * Vector2.right + new Vector2(-8, -2));
    }

    IEnumerator Picking()
    {
        Debug.Log("Picking");
        while(transform.rotation.z <= 0.09)
        {
            transform.Rotate(new Vector3(0, 0, 0.1f));
        }
        yield return null;
    }

    IEnumerator ResetPick()
    {
        Debug.Log("Resetting");
        while (transform.rotation.z >= 0)
        {
            transform.Rotate(new Vector3(0, 0, -0.1f));
        }
        yield return null;
    }

    /*    private void OnMouseDown()
        {
            isClicked = true;
        }

        private void OnMouseUp()
        {
            isClicked = false;
        }*/
}
