using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public int ID = 0;
    public Collider2D collision;
    public static float height = 1.5f;

    private void Start()
    {
        collision.enabled = true;
        transform.Translate(new Vector3(0, height, 0));
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Release());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnTop(collision);
    }

    virtual public void OnTop(Collision2D collision)
    {
        if (collision.transform.position.y > height + collision.transform.localScale.y)
        {
            Debug.Log(collision.transform.position.y + " " + collision.gameObject.name);
            playSound(ID);
        }
    }

    virtual public void Fall()
    {
        StartCoroutine(Release());
    }

    public IEnumerator Release()
    {
        collision.enabled = false;
        yield return new WaitForSeconds(1.2f);
        collision.enabled = true;
        yield return null;
    }
    private static void playSound(int ID)
    {
        Debug.Log(ID);
    }
}
