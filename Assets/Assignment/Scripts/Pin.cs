using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public int ID = 0;
    public Collider2D collision;
    static float height = 1.5f;

    private void Start()
    {
        collision.enabled = true;
        transform.Translate(new Vector3(0, height, 0));
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            collision.enabled = false;
        } else if ((Input.GetMouseButtonUp(1)))
        {
            collision.enabled = true;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.position.y > height + collision.transform.localScale.y/2)
        {
            playSound(ID);
        }
    }

    private static void playSound(int ID)
    {
        Debug.Log(ID);
    }
}
