using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 newPos;
    bool isClicked;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //offset by 8 and lock to x axis
        rb.MovePosition(newPos * Vector2.right + new Vector2 (-8, -2));
        if (Input.GetMouseButton(0)) 
        {
            StopCoroutine(ResetPick());
            StartCoroutine(Picking());

        } else
        {
            StopCoroutine(Picking());
            StartCoroutine(ResetPick());
        }
        /*Debug.Log(transform.rotation.z);
        if (Input.GetMouseButton(0) && transform.rotation.z <= 0.1)
        {
            transform.Rotate(new Vector3(0, 0, 0.1f));
        }
        else if(transform.rotation.z >= 0)
        {
            
            transform.Rotate(new Vector3(0, 0, -0.1f));
        }*/
    }

    IEnumerator Picking()
    {
        Debug.Log("Picking");
        while(transform.rotation.z <= 0.1)
        {
            transform.Rotate(new Vector3(0, 0, 0.1f));
        }
        StartCoroutine(ResetPick());
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
